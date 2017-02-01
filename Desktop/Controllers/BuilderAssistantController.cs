using Business.Interfaces;
using Business.Services;
using Data;
using Data.Domain;
using Desktop.BaseLib;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class BuilderAssistantController
    {
        private IBuilderAssistantView _view;
        private User _user;

        private IUserSetService _userSetService;
        private ILSetService _lSetService;

        private Repository<Theme> _themeRepository;
        private IEnumerable<LSet> _currQuery;
        private List<LSet> _result;

        public BuilderAssistantController(IBuilderAssistantView view, User user)
        {
            _view = view;
            _user = user;

            _userSetService = new UserSetService();
            _lSetService = new LSetService();
            _themeRepository = new Repository<Theme>();

            _result = _lSetService.BuilderAssistent(user.Id);
            _currQuery = _result.AsQueryable();
        }

        public void Load()
        {
            UpdateDataGirdView();
            InitThemeComboBox();
        }

        #region Search
        public void Search()
        {
            //TODO radio btn all/unused
            _currQuery = _result;

            if (_view.Theme.Text != "")
            {
                _currQuery = _currQuery.Where(x=> x.Theme.BaseTheme != null && x.Theme.BaseTheme.Name == _view.Theme.Text);
            }

            if (_view.Subtheme.Text != "") {
                _currQuery = _currQuery.Where(x => x.Theme.Name == _view.Subtheme.Text);
            }

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
                           Theme = (s.Theme.BaseTheme != null) ? s.Theme.BaseTheme.Name : null,
                           //Theme = s.Theme.BaseTheme.Name,
                           Subtheme = s.Theme.Name,
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
        #endregion
    }
}
