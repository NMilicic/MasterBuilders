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
            var sb = new StringBuilder();

            sb.Append("Name:").Append(_view.SearchName).Append(";");
            sb.Append("NadTema:").Append(_view.Theme.SelectedItem).Append(";");
            sb.Append("Tema:").Append(_view.Subtheme.SelectedItem).Append(";");

            _currQuery = _userSetService.Search(_user.Id, sb.ToString());
            UpdateDataGirdView();
        }

        public void UpdateSubthemeComboBox()
        {
            var themeName = (string)_view.Theme.SelectedItem;
            IQueryable<Tema> subthemes;
            if (themeName.Equals("")) {
                subthemes = _themeRepository.Query().Where(x => x.NadTema == null);
            } else {
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
            UpdateControls();
        }
        
        public void RemoveSet()
        {
            var userSet = _userSetService.GetById(GetSelectedUserSetId());
            if (userSet == null)
            {
                return;
            }

            var setId = userSet.Set.Id;
            var qty = _view.RemoveQty;
            
            if (qty > 0)
            {
                _userSetService.RemoveFromInventory(_user.Id, setId, qty);
                if (userSet.Komada < userSet.Slozeno)
                {
                    var disassemble = userSet.Slozeno - userSet.Komada;
                    _userSetService.MarkSetAsCompleted(_user.Id, setId, -disassemble);
                }
                UpdateControls();
                UpdateDataGirdView();
            }
        }

        public void AssembleSet()
        {
            var userSet = _userSetService.GetById(GetSelectedUserSetId());
            if (userSet == null)
            {
                return;
            }

            var setId = userSet.Set.Id;
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
            var userSet = _userSetService.GetById(GetSelectedUserSetId());
            if (userSet == null)
            {
                return;
            }

            var setId = userSet.Set.Id;
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
            _view.Theme.DataSource = data;
            UpdateSubthemeComboBox();
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
                           //Description = s.Set.Opis,
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
            if (_view.DataGridView.SelectedRows.Count == 0)
            {
                return -1;
            } 
            var idString = _view.DataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            var setId = int.Parse(idString);
            return setId;
        }

        private void UpdateControls()
        {
            var set = _userSetService.GetById(GetSelectedUserSetId());
            var noOwned = (set != null) ? set.Komada : 0;
            var noAssembled = (set != null) ? set.Slozeno : 0;

            _view.MaxRemoveQty = noOwned; ;
            _view.MaxAssembleQty = noOwned - noAssembled;
            _view.MaxDisassembleQty = noAssembled;

            _view.RemoveQty = 0;
            _view.AssembleQty = 0;
            _view.DisassembleQty = 0;
        }
        #endregion
    }
}
