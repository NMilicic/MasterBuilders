using Business.Interfaces;
using Business.Services;
using Data;
using Data.Domain;
using Desktop.BaseLib;
using Desktop.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class InventorySetsController
    {
        private IInventorySetsView _view;
        private Korisnik _user;
        private ILSetService _lSetService;
        private IWishlistService _wishlistService;
        private IUserSetService _userSetService;
        private Repository<Tema> _themeRepository;
        private IQueryable<LSet> _currQuery;

        public InventorySetsController(IInventorySetsView view, Korisnik user)
        {
            _view = view;
            _user = user;
            _lSetService = new LSetService();
            _wishlistService = new WishlistService();
            _userSetService = new UserSetService();
            _themeRepository = new Repository<Tema>();
            _currQuery = _lSetService.GetAll();
        }

        public void Load()
        {
            UpdateDataGirdView();
            InitThemeComboBox();
        }

        public void Search()
        {
            //TODO search sets database
            var sb = new StringBuilder();

            sb.Append("Name:").Append(_view.SearchName).Append(";");
            sb.Append("Theme:").Append(_view.Themes.SelectedItem).Append(";");
            sb.Append("Subtheme:").Append("").Append(";");
            sb.Append("YearFrom:").Append("").Append(";");
            sb.Append("YearTo:").Append("").Append(";");
            sb.Append("PartsFrom:").Append("").Append(";");
            sb.Append("PartsTo:").Append("").Append(";");

            _currQuery = _lSetService.Search(sb.ToString());
            UpdateDataGirdView();
        }

        public void UpdateSubthemeComboBox()
        {
            var theme = _view.Themes.SelectedItem;
            //TODO update subtheme combobox
        }

        public void AddToWishlist()
        {
            var setId = GetSelectedSetId();
            var qty = _view.WishlistQty;
            _view.WishlistQty = 0;

            if (qty != 0) { 
                _wishlistService.AddSetToWishlistForUser(_user.Id, setId, qty);
            }

            UpdateDataGirdView();
        }

        public void AddToInventory()
        {
            var setId = GetSelectedSetId();
            var qty = _view.InventoryQty;
            _view.InventoryQty = 0;

            if (qty != 0) { 
                _userSetService.AddToInventory(_user.Id, setId, qty);
            }

            UpdateDataGirdView();
        }

        public void ShowPartlist()
        {
            var setId = GetSelectedSetId();
            var parts = _lSetService.GetById(setId).Dijelovi;

            var data = from p in parts
                       select new
                       {
                           Name = p.Kockica.Ime,
                           Color = p.Boja.Ime,
                           Qty = p.Broj
                       };

            if (data.Count() == 0)
            {
                MessageBox.Show("Partlist not available.");
            }
            else
            {
                var newForm = new frmPartlist(data);
                newForm.ShowDialog();
            }
        }

        public void DownloadInstructions()
        {
            //TODO download instructions
            MessageBox.Show("Instructions not available.");
        }

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
                           Name = s.Ime,
                           Theme = s.Tema.NadTema.ImeTema,
                           Subtheme = s.Tema.ImeTema,
                           Description = s.Opis,
                           Year = s.GodinaProizvodnje,
                           Parts = s.DijeloviBroj,
                           Owned = s.KorisnikSet.Where(x => x.Korisnik.Id == _user.Id).Select(x => x.Komada).FirstOrDefault()
                       };

            _view.DataGridView.DataSource = data.ToList();

            _view.DataGridView.Columns["Id"].Visible = false;
            _view.DataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private int GetSelectedSetId()
        {
            var idString = _view.DataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            var setId = int.Parse(idString);
            return setId;
        }
    }
}
