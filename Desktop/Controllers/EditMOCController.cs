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
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class EditMOCController
    {
        private IFormsFactory _factory;
        private IEditMOCView _view;
        private User _user;
        private Moc _moc;
        private List<MocPart> _parts;

        private IKockiceService _partsService;
        private IMOCService _mocService;
        
        private IRepository<Category> _categoryRepository;
        private IRepository<Color> _colorRepository;
        private IQueryable<Part> _currQuery;

        public EditMOCController(IFormsFactory factory, IEditMOCView view, Moc moc, User user)
        {
            _factory = factory;
            _view = view;
            _user = user;
            
            if (moc != null)
            {
                _moc = moc;
                _parts = moc.MocParts.ToList();
            } else
            {
                _moc = new Moc();
                _parts = new List<MocPart>();
            }

            _partsService = new PartService();
            _mocService = new MOCService();

            _categoryRepository = new Repository<Category>();
            _colorRepository = new Repository<Color>();

            _currQuery = _partsService.GetAll();
        }

        public void Load()
        {
            UpdateDataGirdView();
            InitCategoryComboBox();
            InitColorComboBox();
            _view.AddName = _moc.Name;
            _view.Description = _moc.Description;
            _view.Theme1 = _moc.Theme1;
            _view.Theme2 = _moc.Theme2;
            _view.Theme3 = _moc.Theme3;
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
            var partId = GetSelectedPartId();
            if (partId < 0)
            {
                return;
            }

            var qty = _view.AddQty;
            var colorName = _view.Color.SelectedItem.ToString();
            if (qty > 0 && colorName != "")
            {
                _parts.Add(new MocPart()
                {
                    Color = _colorRepository.Query().Where(x=> x.Name.Equals(_view.Color.SelectedItem.ToString())).FirstOrDefault(),
                    Part = _partsService.GetById(partId),
                    Number = _view.AddQty,
                    Moc = _moc
                });

                _moc.NumberOfParts += _view.AddQty;

                MessageBox.Show("Added " + qty + " " + _view.Color.SelectedItem + " '"
                    + _partsService.GetById(partId).Name + "' to MOC.");
                ClearControls();
            }
        }

        public void ShowPartlist()
        {
            var newForm = (Form)_factory.createEditMOCPartlistView(_parts);
            newForm.ShowDialog();
        }

        public void SaveChanges()
        {
            if (_parts.Count() == 0)
            {
                MessageBox.Show("Please add parts.");
                return;
            }

            _moc.Name = _view.AddName;
            if (_moc.Name == "")
            {
                MessageBox.Show("Please enter MOC name.");
                return;
            }

            _moc.Name = _view.AddName;
            _moc.Theme1 = _view.Theme1;
            _moc.Theme2 = _view.Theme2;
            _moc.Theme3 = _view.Theme3;
            _moc.Description = _view.Description;
            _moc.User = _user;
            _moc.ProductionYear = DateTime.Now.Year;

            
            _mocService.AddMoc(_moc);
            _mocService.AddMocPartToMoc(_moc.Id, _parts);

            MessageBox.Show("MOC Saved!");
            _view.Close();
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

        private int GetSelectedPartId()
        {
            if (_view.DataGridView.SelectedRows.Count == 0)
            {
                return -1;
            }

            var idString = _view.DataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            var partId = int.Parse(idString);

            return partId;
        }

        private void ClearControls()
        {
            _view.Color.SelectedIndex = 0;
            _view.AddQty = 0;
        }
        #endregion
    }
}
