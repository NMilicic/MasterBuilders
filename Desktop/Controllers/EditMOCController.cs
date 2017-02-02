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
        private IEditMOCView _view;
        private User _user;
        private Moc _moc;
        private IEnumerable<MocPart> _parts;

        private IKockiceService _partsService;
        private IMOCService _mocService;
        
        private IRepository<Category> _categoryRepository;
        private IRepository<Color> _colorRepository;
        private IQueryable<Part> _currQuery;

        public EditMOCController(IEditMOCView view, Moc moc, User user)
        {
            _view = view;
            _user = user;
            
            if (moc != null)
            {
                _moc = moc;
                _view.AddName = moc.Name;
                _view.Description = moc.Description;
                _view.Theme1 = moc.Theme1;
                _view.Theme2 = moc.Theme2;
                _view.Theme3 = moc.Theme3;
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
            if (qty > 0)
            {
                _moc.MocParts.ToList().Add(new MocPart()
                {
                    Color = (Color)_view.Color.SelectedItem,
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
            var newForm = new frmMOCPartlist(_moc.MocParts);
            newForm.ShowDialog();
        }

        public void SaveChanges()
        {
            if (_moc.MocParts.Count() == 0)
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
            _moc.AuthorId = _user.Id;
            _moc.ProductionYear = DateTime.Now.Year;

            
            _mocService.AddMoc(_moc);
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
