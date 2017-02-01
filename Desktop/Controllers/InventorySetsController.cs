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
    class InventorySetsController
    {
        private IInventorySetsView _view;
        private User _user;

        private IUserSetService _userSetService;
        private ILSetService _lSetService;

        private Repository<Theme> _themeRepository;
        private IQueryable<UserLSet> _currQuery;

        public InventorySetsController(IInventorySetsView view, User user)
        {
            _view = view;
            _user = user;

            _userSetService = new UserSetService();
            _lSetService = new LSetService();
            _themeRepository = new Repository<Theme>();

            _currQuery = _userSetService.GetAllForUser(user.Id);
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

            _currQuery = _userSetService.Search(_user.Id, sb.ToString());
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
            UpdateControls();
        }
        
        public void RemoveSet()
        {
            var userSet = _userSetService.GetById(GetSelectedUserSetId());
            if (userSet == null)
            {
                return;
            }

            var setId = userSet.LSet.Id;
            var qty = _view.RemoveQty;
            
            if (qty > 0)
            {
                _userSetService.RemoveFromInventory(_user.Id, setId, qty);

                if (userSet.Owned < userSet.Built)
                {
                    var disassemble = userSet.Built - userSet.Owned;
                    _userSetService.MarkSetAsCompleted(_user.Id, setId, -disassemble);
                }

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

            var setId = userSet.LSet.Id;
            var qty = _view.AssembleQty;
            
            if (qty > 0)
            {
                _userSetService.MarkSetAsCompleted(_user.Id, setId, qty);
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

            var setId = userSet.LSet.Id;
            var qty = _view.DisassembleQty;
            
            if (qty > 0)
            {
                _userSetService.MarkSetAsCompleted(_user.Id, setId, -qty);
                UpdateDataGirdView();
            }
        }

        public void DownloadInstructions()
        {
            var userSetId = GetSelectedUserSetId();
            if (userSetId < 0)
            {
                return;
            }

            var setId = _userSetService.GetById(userSetId).LSet.Id;
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
                           Name = s.LSet.Name,
                           Theme = s.LSet.Theme.BaseTheme.Name,
                           Subtheme = s.LSet.Theme.Name,
                           Owned = s.Owned,
                           Assembled = s.Built,
                       };
                       
            _view.DataGridView.DataSource = data.ToList();

            _view.DataGridView.Columns["Id"].Visible = false;
            _view.DataGridView.Columns["Owned"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _view.DataGridView.Columns["Assembled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            UpdateControls();
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
            var noOwned = (set != null) ? set.Owned : 0;
            var noAssembled = (set != null) ? set.Built : 0;

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
