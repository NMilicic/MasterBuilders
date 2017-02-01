using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.Views;
using Desktop.BaseLib;
using Business.Interfaces;
using Data.Domain;
using Data;
using Business.Services;

namespace Desktop.Controllers
{
    class AddPartsController
    {
        private IAddPartsView _view;

        private IKockiceService _partsService;
        
        private IRepository<Category> _categoryRepository;
        private IRepository<Color> _colorRepository;
        private IQueryable<Part> _currQuery;

        public AddPartsController(IAddPartsView view)
        {
            _view = view;
            _partsService = new PartService();
            _categoryRepository = new Repository<Category>();
            _colorRepository = new Repository<Color>();
            _currQuery = _partsService.GetAll();
        }

        public void Load()
        {
            UpdateDataGirdView();
            InitCategoryComboBox();
            InitColorComboBox();
        }

        public void Search()
        {
            var sb = new StringBuilder();

            sb.Append("Name:").Append(_view.SearchName).Append(";");
            sb.Append("Category:").Append(_view.Category.SelectedItem).Append(";");

            _currQuery = _partsService.Search(sb.ToString());
            UpdateDataGirdView();
        }

        public void PartSelected()
        {
            ClearControls();
        }

        public void Add()
        {
            //TODO implement btnAdd
            ClearControls();
        }

        #region Helper Methods
        private void InitCategoryComboBox()
        {
            var categories = _categoryRepository.Query();
            var categoryNames = from c in categories select c.Name;
            var data = categoryNames.ToList();
            data.Insert(0, "");
            _view.Category.DataSource = data;
        }

        private void InitColorComboBox()
        {
            var colors = _colorRepository.Query();
            var colorNames = from c in colors select c.Name;
            var data = colorNames.ToList();
            data.Insert(0, "");
            _view.Color.DataSource = data;
        }

        private void UpdateDataGirdView()
        {
            var data = from p in _currQuery
                       select new
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Category = p.Category.Name,
                       };

            _view.DataGridView.DataSource = data.ToList();
            _view.DataGridView.Columns["Id"].Visible = false;
        }

        private void ClearControls()
        {
            _view.Color.SelectedIndex = 0;
            _view.AddQty = 0;
        }
        #endregion
    }
}
