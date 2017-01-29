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
    class DatabasePartsController
    {
        private IDatabasePartsView _view;
        
        private IKockiceService _partsService;

        private IRepository<Kategorija> _categoryRepository;
        private IQueryable<Kockica> _currQuery;

        public DatabasePartsController(IDatabasePartsView view)
        {
            _view = view;
            _partsService = new KockiceService();
            _categoryRepository = new Repository<Kategorija>();
            _currQuery = _partsService.GetAll();
        }

        public void Load()
        {
            UpdateDataGirdView();
            InitCategoryComboBox();
        }

        public void Search()
        {
            var sb = new StringBuilder();

            sb.Append("Name:").Append(_view.SearchName).Append(";");
            sb.Append("kategorija:").Append(_view.Category.SelectedItem).Append(";");

            _currQuery = _partsService.Search(sb.ToString());
            UpdateDataGirdView();
        }
        
        #region Helper Methods
        private void InitCategoryComboBox()
        {
            var categories = _categoryRepository.Query();
            var categoryNames = from c in categories select c.Ime;
            var data = categoryNames.ToList();
            data.Insert(0, "");
            _view.Category.DataSource = data;
        }

        private void UpdateDataGirdView()
        {
            var data = from s in _currQuery
                       select new
                       {
                           Id = s.Id,
                           Name = s.Ime,
                           Category = s.Kategorija.Ime,
                       };

            _view.DataGridView.DataSource = data.ToList();
            _view.DataGridView.Columns["Id"].Visible = false;
        }
        #endregion
    }
}
