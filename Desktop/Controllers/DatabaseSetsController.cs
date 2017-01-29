using Business.Interfaces;
using Business.Services;
using Data;
using Data.Domain;
using Desktop.BaseLib;
using Desktop.Views;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class DatabaseSetsController
    {
        private IDatabaseSetsView _view;
        private Korisnik _user;

        private ILSetService _lSetService;
        private IWishlistService _wishlistService;
        private IUserSetService _userSetService;

        private Repository<Tema> _themeRepository;
        private IQueryable<LSet> _currQuery;

        public DatabaseSetsController(IDatabaseSetsView view, Korisnik user)
        {
            _view = view;
            _user = user;

            _lSetService = new LSetService();
            _wishlistService = new WishlistService();
            _userSetService = new UserSetService();

            _themeRepository = new Repository<Tema>();
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
            sb.Append("NadTema:").Append(_view.Theme.SelectedItem).Append(";");
            sb.Append("Tema:").Append(_view.Subtheme.SelectedItem).Append(";");
            sb.Append("GodinaProizvodnje:").Append(_view.SearchYearFrom).Append("-").Append(_view.SearchYearTo).Append(";");
            sb.Append("BrojKockica:").Append(_view.SearchPartsFrom).Append("-").Append(_view.SearchPartsTo).Append(";");

            _currQuery = _lSetService.Search(sb.ToString());
            UpdateDataGirdView();
        }

        public void UpdateSubthemeComboBox()
        {
            var themeName = (string)_view.Theme.SelectedItem;
            IQueryable<Tema> subthemes;
            if (themeName.Equals(""))
            {
                subthemes = _themeRepository.Query().Where(x => x.NadTema == null);
            }
            else
            {
                subthemes = _themeRepository.Query().Where(x => x.NadTema.ImeTema == themeName);
            }

            var subthemeNames = from t in subthemes select t.ImeTema;
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
                MessageBox.Show("Added " + qty + " '" + _lSetService.GetById(setId).Ime + "' sets to Wishlist.");
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
                MessageBox.Show("Added " + qty + " '" + _lSetService.GetById(setId).Ime + "' sets to Inventory.");
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

            var parts = _lSetService.GetById(setId).Dijelovi;

            if (parts.Count() == 0)
            {
                MessageBox.Show("Partlist not available.");
            } else
            {
                var newForm = new frmPartlist(parts);
                newForm.ShowDialog();
            }
        }

        public void ShowPicture()
        {
            //TODO show picture
            MessageBox.Show("Picture not available.");
        }

        public void DownloadInstructions()
        {
            //TODO download instructions
            MessageBox.Show("Instructions not available.");
        }

        #region Helper Methods
        private void InitThemeComboBox()
        {
            var themes = _themeRepository.Query();
            var themeNames = from t in themes select t.ImeTema;
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
                           Name = s.Ime,
                           Theme = s.Tema.NadTema.ImeTema,
                           Subtheme = s.Tema.ImeTema,
                           //Description = s.Opis,
                           Year = s.GodinaProizvodnje,
                           Parts = s.DijeloviBroj
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
