using Business.Interfaces;
using Business.Services;
using Data;
using Data.Domain;
using Desktop.BaseLib;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class MOCController
    {
        private IFormsFactory _factory;
        private IMOCView _view;
        
        private IMOCService _MOCService;
        private IWishlistService _wishlistService;
        private IUserSetService _userSetService;

        private Repository<Theme> _themeRepository;
        private IQueryable<Moc> _currQuery;

        public MOCController(IFormsFactory factory, IMOCView view)
        {
            _factory = factory;
            _view = view;
            
            _MOCService = new MOCService();
            _wishlistService = new WishlistService();
            _userSetService = new UserSetService();

            _themeRepository = new Repository<Theme>();
            _currQuery = _MOCService.GetAll();
        }

        public void Load()
        {
            UpdateDataGirdView();
        }

        #region Search
        public void Search()
        {
            var sb = new StringBuilder();

            sb.Append("Name:").Append(_view.SearchName).Append(";");
            sb.Append("Theme:").Append(_view.Theme).Append(";");
            sb.Append("Author:").Append(_view.Author).Append(";");
            sb.Append("ProductionYear:").Append(_view.SearchYearFrom).Append("-").Append(_view.SearchYearTo).Append(";");
            sb.Append("NumberOfParts:").Append(_view.SearchPartsFrom).Append("-").Append(_view.SearchPartsTo).Append(";");

            _currQuery = _MOCService.Search(sb.ToString());
            UpdateDataGirdView();
        }
        #endregion
        

        public void ShowPartlist()
        {
            var setId = GetSelectedMOCId();
            if (setId < 0)
            {
                return;
            }

            var parts = _MOCService.GetById(setId).MocParts;

            if (parts.Count() == 0)
            {
                MessageBox.Show("Partlist not available.");
            } else
            {
                var newForm = (Form)_factory.createMOCPartlistView(parts);
                newForm.ShowDialog();
            }
        }

        #region Helper Methods
        private void UpdateDataGirdView()
        {
            var data = from m in _currQuery
                       select new
                       {
                           Id = m.Id,
                           Name = m.Name,
                           Description = m.Description,
                           Theme1 = m.Theme1,
                           Theme2 = m.Theme2,
                           Theme3 = m.Theme3,
                           Year = m.ProductionYear,
                           Parts = m.NumberOfParts,
                           Author = m.User.FirstName + " " + m.User.LastName,
                       };

            _view.DataGridView.DataSource = data.ToList();

            _view.DataGridView.Columns["Id"].Visible = false;
            _view.DataGridView.Columns["Year"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _view.DataGridView.Columns["Parts"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private int GetSelectedMOCId()
        {
            if (_view.DataGridView.SelectedRows.Count == 0)
            {
                return -1;
            }

            var idString = _view.DataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            var MOCId = int.Parse(idString);

            return MOCId;
        }
        #endregion
    }
}
