using Business.Interfaces;
using Business.Services;
using Data.Domain;
using Desktop.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class DatabasePartsController
    {
        private IDatabasePartsView _view;
        private Korisnik _user;

        private IKockiceService _partsService;
        private IKorisnikService _userService;

        //TODO category repository
        private IQueryable<Kockica> _currQuery;

        public DatabasePartsController(IDatabasePartsView view, Korisnik user)
        {
            _view = view;
            _user = user;

            _partsService = new KockiceService();
            _userService = new KorisnikServices();

            _currQuery = _partsService.GetAll();
        }

        public void Load()
        {
            UpdateDataGirdView();
            InitCategoryComboBox();
        }

        public void Search()
        {
            //TODO search sets database
            var sb = new StringBuilder();

            sb.Append("Name:").Append(_view.SearchName).Append(";");
            sb.Append("Category:").Append(_view.Category.SelectedItem).Append(";");
            sb.Append("Color:").Append(_view.Color.SelectedItem).Append(";");

            //_currQuery = _partsService.Search(sb.ToString());
            UpdateDataGirdView();
        }
        
        public void PartSelected()
        {
            ClearControls();
        }

        /*
        public void AddToWishlist()
        {
            var setId = GetSelectedSetId();
            var qty = _view.WishlistQty;

            if (qty != 0)
            {
                _wishlistService.AddSetToWishlistForUser(_user.Id, setId, qty);
                MessageBox.Show("Added " + qty + " '" + _partsService.GetById(setId).Ime + "' sets to Wishlist.");
                ClearControls();
                //UpdateDataGirdView();
            }
        }
        */

        public void AddToInventory()
        {
            /*
            var setId = GetSelectedSetId();
            var qty = _view.InventoryQty;

            if (qty != 0)
            {
                _userPartsService.AddToInventory(_user.Id, setId, qty);
                MessageBox.Show("Added " + qty + " '" + _partsService.GetById(setId).Ime + "' sets to Inventory.");
                ClearControls();
                //UpdateDataGirdView();
            }
            */
        }

        #region Helper Methods
        private void InitCategoryComboBox()
        {
            /*TODO
            var categories = _themeRepository.Query();
            var categoryNames = from c in categories select c.ImeTema;
            var data = categoryNames.ToList();
            data.Insert(0, "");
            _view.Category.DataSource = data;
            */
        }

        private void UpdateDataGirdView()
        {
            var data = from s in _currQuery
                       select new
                       {
                           Id = s.Id,
                           Name = s.Ime,
                           Category = s.Kategorija,
                           //Color = s.Boja,
                       };

            _view.DataGridView.DataSource = data.ToList();

            _view.DataGridView.Columns["Id"].Visible = false;
        }

        private int GetSelectedSetId()
        {
            var idString = _view.DataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            var setId = int.Parse(idString);
            return setId;
        }

        private void ClearControls()
        {
            _view.InventoryQty = 0;
            //_view.WishlistQty = 0;
        }
        #endregion
    }
}
