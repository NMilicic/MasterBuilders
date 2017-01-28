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
    class DatabaseSetsController
    {
        private IDatabaseSetsView _view;
        private Korisnik _user;
        private ILSetService _lSetService;
        private IWishlistService _wishlistService;
        private IUserSetService _userSetService;
        Repository<Tema> _themeRepository;

        public DatabaseSetsController(IDatabaseSetsView view, Korisnik user)
        {
            _view = view;
            _user = user;
            _lSetService = new LSetService();
            _wishlistService = new WishlistService();
            _userSetService = new UserSetService();
            _themeRepository = new Repository<Tema>();
        }

        public void InitDataGridView()
        {
            UpdateDataGirdView(_lSetService.GetAll());
        }

        public void InitThemeComboBox()
        {
            var themes = _themeRepository.Query();
            var themeNames = from t in themes select t.ImeTema;
            var data = themeNames.ToList();
            data.Insert(0, "");
            _view.Themes.DataSource = data;
        }

        public void UpdateSubthemeComboBox()
        {
            var theme = _view.Themes.SelectedItem;
            //TODO update subtheme combobox
        }

        public void Search()
        {
            //TODO search sets database
            //string searchParameters = "";
            //UpdateDataGirdView(_service.Search(searchParameters));
        }

        public void AddToWishlist()
        {
            var setId = GetSelectedSetId();
            var qty = _view.WishlistQty;
            if (qty != 0) { 
                _wishlistService.AddSetToWishlistForUser(_user.Id, setId, qty);
            }
        }

        public void AddToInventory()
        {
            var setId = GetSelectedSetId();
            var qty = _view.InventoryQty;
            if (qty != 0) { 
                _userSetService.AddToInventory(_user.Id, setId, qty);
            }
        }

        public void ShowPartlist()
        {
            //TODO showpartlist service ?
        }

        public void DownloadInstructions()
        {
            //TODO download instructions
        }

        private void UpdateDataGirdView(IQueryable<LSet> query)
        {
            var tmp = from q in query select q.KorisnikSet;
            var tmp2 = tmp.ToList();

            var data = from q in query
                       select new
                       {
                           Id = q.Id,
                           Name = q.Ime,
                           Theme = q.Tema.NadTema.ImeTema,
                           Subtheme = q.Tema.ImeTema,
                           Description = q.Opis,
                           Year = q.GodinaProizvodnje,
                           Parts = q.DijeloviBroj,
                           //TODO fix owned column contents
                           Owned = q.KorisnikSet.Where(s => s.Korisnik.Id == _user.Id)
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
