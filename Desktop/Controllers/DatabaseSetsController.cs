using Business.Interfaces;
using Business.Services;
using Data;
using Data.Domain;
using Desktop.BaseLib;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class DatabaseSetsController
    {
        private IFormsFactory _factory;
        private IDatabaseSetsView _view;
        private User _user;

        private ILSetService _lSetService;
        private IWishlistService _wishlistService;
        private IUserSetService _userSetService;

        private Repository<Theme> _themeRepository;
        private IQueryable<LSet> _currQuery;

        public DatabaseSetsController(IFormsFactory factory, IDatabaseSetsView view, User user)
        {
            _factory = factory;
            _view = view;
            _user = user;

            _lSetService = new LSetService();
            _wishlistService = new WishlistService();
            _userSetService = new UserSetService();

            _themeRepository = new Repository<Theme>();
            _currQuery = _lSetService.GetAll();
        }

        public void Load()
        {
            UpdateDataGirdView();
            InitThemeComboBox();
        }

        #region Search
        public void Search()
        {
            var sb = new StringBuilder();

            sb.Append("Name:").Append(_view.SearchName).Append(";");
            sb.Append("BaseTheme:").Append(_view.Theme.SelectedItem).Append(";");
            sb.Append("Theme:").Append(_view.Subtheme.SelectedItem).Append(";");
            sb.Append("ProductionYear:").Append(_view.SearchYearFrom).Append("-").Append(_view.SearchYearTo).Append(";");
            sb.Append("NumberOfParts:").Append(_view.SearchPartsFrom).Append("-").Append(_view.SearchPartsTo).Append(";");

            _currQuery = _lSetService.Search(sb.ToString());
            UpdateDataGirdView();
        }

        public void UpdateSubthemeComboBox()
        {
            IQueryable<Theme> subthemes;
            var themeName = (string)_view.Theme.SelectedItem;

            if (themeName.Equals(""))
            {
                subthemes = _themeRepository.Query().Where(x => x.BaseTheme == null);
            }
            else
            {
                subthemes = _themeRepository.Query().Where(x => x.BaseTheme.Name == themeName);
            }

            var subthemeNames = from t in subthemes select t.Name;
            var data = subthemeNames.ToList();
            data.Insert(0, "");
            _view.Subtheme.DataSource = data;
        }
        #endregion

        public void SetSelected()
        {
            ClearControls();
        }

        public void AddToWishlist()
        {
            var setId = GetSelectedSetId();
            if (setId < 0)
            {
                return;
            }

            var qty = _view.WishlistQty;
            
            if (qty > 0)
            {
                _wishlistService.AddSetToWishlistForUser(_user.Id, setId, qty);
                MessageBox.Show("Added " + qty + " '" + _lSetService.GetById(setId).Name + "' sets to Wishlist.");
                ClearControls();
            }
        }

        public void AddToInventory()
        {
            var setId = GetSelectedSetId();
            if (setId < 0)
            {
                return;
            }
            var qty = _view.InventoryQty;
            
            if (qty > 0) {
                _userSetService.AddToInventory(_user.Id, setId, qty);
                MessageBox.Show("Added " + qty + " '" + _lSetService.GetById(setId).Name + "' sets to Inventory.");
                ClearControls();
            }
        }

        public void ShowPartlist()
        {
            var setId = GetSelectedSetId();
            if (setId < 0)
            {
                return;
            }

            var parts = _lSetService.GetById(setId).LSetParts;

            if (parts.Count() == 0)
            {
                MessageBox.Show("Partlist not available.");
            } else
            {
                var newForm = (Form)_factory.createSetPartlistView(parts);
                newForm.ShowDialog();
            }
        }

        public void ShowPicture()
        {
            var setId = GetSelectedSetId();
            if (setId < 0)
            {
                return;
            }

            var url = _lSetService.GetById(setId).PictureUrl;
            var newForm = (Form)_factory.createPictureView(url);
            newForm.ShowDialog();
        }

        public void DownloadInstructions()
        {
            var setId = GetSelectedSetId();
            if (setId < 0)
            {
                return;
            }

            var url = _lSetService.GetById(setId).InstructionsUrl;
            Process.Start(url);
        }

        #region Helper Methods
        private void InitThemeComboBox()
        {
            var themes = _themeRepository.Query();
            var themeNames = from t in themes select t.Name;
            var data = themeNames.ToList();
            data.Insert(0, "");
            _view.Theme.DataSource = data;
            UpdateSubthemeComboBox();
        }

        private void UpdateDataGirdView()
        {
            var data = from s in _currQuery
                       select new
                       {
                           Id = s.Id,
                           Name = s.Name,
                           Theme = s.Theme.BaseTheme.Name,
                           Subtheme = s.Theme.Name,
                           Description = s.Description,
                           Year = s.ProductionYear,
                           Parts = s.NumberOfParts
                       };

            _view.DataGridView.DataSource = data.ToList();

            _view.DataGridView.Columns["Id"].Visible = false;
            _view.DataGridView.Columns["Year"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _view.DataGridView.Columns["Parts"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private int GetSelectedSetId()
        {
            if (_view.DataGridView.SelectedRows.Count == 0)
            {
                return -1;
            }

            var idString = _view.DataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            var setId = int.Parse(idString);

            return setId;
        }

        private void ClearControls()
        {
            _view.InventoryQty = 0;
            _view.WishlistQty = 0;
        }
        #endregion
    }
}
