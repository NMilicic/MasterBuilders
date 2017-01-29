using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain;
using Desktop.Views;
using Desktop.BaseLib;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class InventoryPartsController
    {
        private IInventoryPartsView _view;
        private Korisnik _user;

        //TODO category repository
        private IQueryable<UserSet> _currQuery;

        public InventoryPartsController(IInventoryPartsView view, Korisnik user)
        {
            _view = view;
            _user = user;
        }

        public void Load()
        {
            UpdateDataGirdView();
            SetSelected();
            InitCategoryComboBox();
        }

        #region Search
        public void Search()
        {
            //TODO search sets inventory
            var sb = new StringBuilder();

            sb.Append("Name:").Append(_view.SearchName).Append(";");
            sb.Append("Category:").Append(_view.Category.SelectedItem).Append(";");
            sb.Append("Color:").Append("").Append(";");

            //_currQuery = _userSetService.Search(sb.ToString());
            UpdateDataGirdView();
        }

        public void UpdateSubthemeComboBox()
        {
            //var theme = _view.Categories.SelectedItem;
            //TODO update subtheme combobox
        }
        #endregion

        public void SetSelected()
        {
            UpdateControls();
        }

        public void RemovePart()
        {
            /*
            var userPart = _userPartService.GetById(GetSelectedUserPartId());
            if (userPart == null)
            {
                return;
            }

            var setId = userPart.Set.Id;
            var qty = _view.RemoveQty;

            if (qty > 0)
            {
                _userSetService.RemoveFromInventory(_user.Id, setId, qty);
                UpdateControls();
                UpdateDataGirdView();
            }
            */
        }

        #region Helper Methods
        private void InitCategoryComboBox()
        {
            /*
            var categories = _categoryRepository.Query();
            var categoryNames = from c in categories select c.ImeTema;
            var data = categoryNames.ToList();
            data.Insert(0, "");
            _view.Category.DataSource = data;
            */
        }

        private void UpdateDataGirdView()
        {
            /*
            var data = from s in _currQuery
                       select new
                       {
                           Id = s.Id,
                           Name = s.Set.Ime,
                           Category = s.Kockica.Kategorija,
                           Color = s.Boja,
                           Owned = s.Komada,
                       };

            _view.DataGridView.DataSource = data.ToList();

            _view.DataGridView.Columns["Id"].Visible = false;
            _view.DataGridView.Columns["Owned"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            */
        }

        private int GetSelectedUserPartId()
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
            /*
            var set = _userPartService.GetById(GetSelectedUserPartId());
            var noOwned = (set != null) ? set.Komada : 0;
            var noAssembled = (set != null) ? set.Slozeno : 0;

            _view.MaxRemoveQty = noOwned;
            _view.RemoveQty = 0;
            */
        }
        #endregion
    }
}
