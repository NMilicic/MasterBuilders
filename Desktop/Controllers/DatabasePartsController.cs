using Business.Interfaces;
using Business.Services;
using Data;
using Data.Domain;
using Desktop.BaseLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class DatabasePartsController
    {
        private IFormsFactory _factory;
        private IDatabasePartsView _view;
        
        private IKockiceService _partsService;
        private ILSetService _lSetService;

        private IRepository<Category> _categoryRepository;
        private IQueryable<Part> _currQuery;

        public DatabasePartsController(IFormsFactory factory, IDatabasePartsView view)
        {
            _factory = factory;
            _view = view;
            _partsService = new PartService();
            _lSetService = new LSetService();
            _categoryRepository = new Repository<Category>();
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
            sb.Append("Category:").Append(_view.Category.SelectedItem).Append(";");

            _currQuery = _partsService.Search(sb.ToString());
            UpdateDataGirdView();
        }

        public void RecommendSets()
        {
            var parts = new List<int>();

            for (int i = 0; i <_view.DataGridView.SelectedRows.Count; i++)
            {
                var idString = _view.DataGridView.SelectedRows[i].Cells["Id"].Value.ToString();
                parts.Add(int.Parse(idString));
            }

            if(parts.Count == 0)
            {
                return;
            }
            
            var sets = _lSetService.GetAllSetsWithBricks(parts);

            if (sets.Count() == 0)
            {
                MessageBox.Show("Part not found in any sets.");
            }
            else
            {
                var newForm = (Form)_factory.createSetlistView(sets);
                newForm.ShowDialog();
            }
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
        
        #endregion
    }
}
