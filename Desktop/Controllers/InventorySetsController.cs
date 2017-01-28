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
    class InventorySetsController
    {
        private IInventorySetsView _view;
        private Korisnik _user;

        private IUserSetService _userSetService;

        private Repository<Tema> _themeRepository;
        private IQueryable<UserSet> _currQuery;

        public InventorySetsController(IInventorySetsView view, Korisnik user)
        {
            _view = view;
            _user = user;

            _userSetService = new UserSetService();
            _themeRepository = new Repository<Tema>();

            _currQuery = _userSetService.GetAllForUser(user.Id);
        }

        public void Load()
        {
            UpdateDataGirdView();
            SetSelected();
            InitThemeComboBox();
        }

        #region Search
        public void Search()
        {
            //TODO search sets inventory
            var sb = new StringBuilder();

            sb.Append("Name:").Append(_view.SearchName).Append(";");
            sb.Append("Theme:").Append(_view.Themes.SelectedItem).Append(";");
            sb.Append("Subtheme:").Append("").Append(";");
            sb.Append("YearFrom:").Append("").Append(";");
            sb.Append("YearTo:").Append("").Append(";");
            sb.Append("PartsFrom:").Append("").Append(";");
            sb.Append("PartsTo:").Append("").Append(";");

            //_currQuery = _userSetService.Search(sb.ToString());
            UpdateDataGirdView();
        }

        public void UpdateSubthemeComboBox()
        {
            var theme = _view.Themes.SelectedItem;
            //TODO update subtheme combobox
        }
        #endregion

        public void SetSelected()
        {
            UpdateControls();
        }
        
        public void RemoveSet()
        {
            var setId = _userSetService.GetById(GetSelectedUserSetId()).Set.Id;
            var qty = _view.RemoveQty;
            
            if (qty > 0)
            {
                _userSetService.RemoveFromInventory(_user.Id, setId, qty);
                UpdateControls();
                UpdateDataGirdView();
            }
        }

        public void AssembleSet()
        {
            var setId = _userSetService.GetById(GetSelectedUserSetId()).Set.Id;
            var qty = _view.AssembleQty;
            
            if (qty > 0)
            {
                _userSetService.MarkSetAsCompleted(_user.Id, setId, qty);
                UpdateControls();
                UpdateDataGirdView();
            }
        }

        public void DisassembleSet()
        {
            var setId = _userSetService.GetById(GetSelectedUserSetId()).Set.Id;
            var qty = _view.DisassembleQty;
            
            if (qty > 0)
            {
                _userSetService.MarkSetAsCompleted(_user.Id, setId, -qty);
                UpdateControls();
                UpdateDataGirdView();
            }
        }

    #region Helper Methods
        private void InitThemeComboBox()
        {
            var themes = _themeRepository.Query();
            var themeNames = from t in themes select t.ImeTema;
            var data = themeNames.ToList();
            data.Insert(0, "");
            _view.Themes.DataSource = data;
        }

        private void UpdateDataGirdView()
        {
            var data = from s in _currQuery
                       select new
                       {
                           Id = s.Id,
                           Name = s.Set.Ime,
                           Theme = s.Set.Tema.NadTema.ImeTema,
                           Subtheme = s.Set.Tema.ImeTema,
                           Description = s.Set.Opis,
                           Owned = s.Komada,
                           Assembled = s.Slozeno,
                       };
                       
            _view.DataGridView.DataSource = data.ToList();

            _view.DataGridView.Columns["Id"].Visible = false;
            _view.DataGridView.Columns["Owned"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _view.DataGridView.Columns["Assembled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private int GetSelectedUserSetId()
        {
            var idString = _view.DataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            var setId = int.Parse(idString);
            return setId;
        }

        private void UpdateControls()
        {
            var noOwned = _userSetService.GetById(GetSelectedUserSetId()).Komada;
            var noAssembled = _userSetService.GetById(GetSelectedUserSetId()).Slozeno;

            _view.MaxRemoveQty = noOwned;
            _view.MaxAssembleQty = noOwned - noAssembled;
            _view.MaxDisassembleQty = noAssembled;

            _view.RemoveQty = 0;
            _view.AssembleQty = 0;
            _view.DisassembleQty = 0;
        }
        #endregion
    }
}
