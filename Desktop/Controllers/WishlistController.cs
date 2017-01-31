using Business.Interfaces;
using Business.Services;
using Data;
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
    class WishlistController
    {
        private IWishlistView _view;
        private User _user;

        private IWishlistService _wishlistService;

        private Repository<Theme> _themeRepository;
        private IQueryable<Wishlist> _currQuery;

        public WishlistController(IWishlistView view, User user)
        {
            _view = view;
            _user = user;

            _wishlistService = new WishlistService();
            _themeRepository = new Repository<Theme>();

            _currQuery = _wishlistService.GetAllSetsFromWishlistForUser(user.Id);
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

            _currQuery = _wishlistService.Search(_user.Id, sb.ToString());
            UpdateDataGirdView();
        }

        public void UpdateSubthemeComboBox()
        {
            var themeName = (string)_view.Theme.SelectedItem;
            IQueryable<Theme> subthemes;
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
            var wishlistSet = _wishlistService.GetById(GetSelectedWishlistSetId());
            if (wishlistSet == null)
            {
                return;
            }

            var setId = wishlistSet.LSet.Id;
            var qty = _view.RemoveQty;

            if (qty > 0)
            {
                _wishlistService.RemoveSetFromWishlistForUser(_user.Id, setId, qty);
                UpdateControls();
                UpdateDataGirdView();
            }
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
                           Description = s.LSet.Description,
                           Quantity = s.Number
                       };

            _view.DataGridView.DataSource = data.ToList();

            _view.DataGridView.Columns["Id"].Visible = false;
            _view.DataGridView.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private int GetSelectedWishlistSetId()
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
            var set = _wishlistService.GetById(GetSelectedWishlistSetId());
            var noWished = (set != null) ? set.Number : 0;
            _view.MaxRemoveQty = noWished;
            _view.RemoveQty = 0;
        }
        #endregion
    }
}

