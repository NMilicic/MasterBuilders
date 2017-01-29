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
        private Korisnik _user;

        private IWishlistService _wishlistService;

        private Repository<Tema> _themeRepository;
        private IQueryable<Wishlist> _currQuery;

        public WishlistController(IWishlistView view, Korisnik user)
        {
            _view = view;
            _user = user;

            _wishlistService = new WishlistService();
            _themeRepository = new Repository<Tema>();

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
            UpdateControls();
        }

        public void RemoveSet()
        {
            var wishlistSet = _wishlistService.GetById(GetSelectedWishlistSetId());
            if (wishlistSet == null)
            {
                return;
            }

            var setId = wishlistSet.Set.Id;
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
                           Description = s.Set.Opis,
                           Quantity = s.Komada
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
            var noWished = (set != null) ? set.Komada : 0;
            _view.MaxRemoveQty = noWished;
            _view.RemoveQty = 0;
        }
        #endregion
    }
}

