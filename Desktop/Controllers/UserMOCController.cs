using Business.Interfaces;
using Business.Services;
using Data;
using Data.Domain;
using Desktop.BaseLib;
using Desktop.Views;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class UserMOCController
    {
        private IUserMOCView _view;
        private User _user;

        private IMOCService _MOCService;
        
        private IQueryable<Moc> _currQuery;

        public UserMOCController(IUserMOCView view, User user)
        {
            _view = view;
            _user = user;

            _MOCService = new MOCService();
        
            _currQuery = _MOCService.GetAllByAuthor(user.Id);
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

            _currQuery = _MOCService.Search(sb.ToString()).Where(x=> x.AuthorId == _user.Id);
            UpdateDataGirdView();
        }

        #endregion

        public void EditMOC()
        {
            var mocID = GetSelectedMOCId();
            if (mocID < 0)
            {
                return;
            }

            var moc = _MOCService.GetById(mocID);

            var newForm = new frmEditMOC(_user, moc);
            newForm.ShowDialog();

            UpdateDataGirdView();
        }

        public void AddMOC()
        {
            var newForm = new frmEditMOC(_user, null);
            newForm.ShowDialog();

            UpdateDataGirdView();
        }

        public void RemoveMOC()
        {
            var mocID = GetSelectedMOCId();
            if (mocID < 0)
            {
                return;
            }

            _MOCService.RemoveMoc(_user.Id, mocID);

            UpdateDataGirdView();
        }

        #region Helper Methods
        private void UpdateDataGirdView()
        {
            var data = from s in _currQuery
                       select new
                       {
                           Id = s.Id,
                           Name = s.Name,
                           Theme1 = s.Theme1,
                           Theme2 = s.Theme2,
                           Theme3 = s.Theme3,
                           Parts = s.NumberOfParts,
                       };
                       
            _view.DataGridView.DataSource = data.ToList();

            _view.DataGridView.Columns["Id"].Visible = false;
            _view.DataGridView.Columns["Parts"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private int GetSelectedMOCId()
        {
            if (_view.DataGridView.SelectedRows.Count == 0)
            {
                return -1;
            } 

            var idString = _view.DataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            var mocId = int.Parse(idString);

            return mocId;
        }
        #endregion
    }
}
