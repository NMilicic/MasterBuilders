using Business.Interfaces;
using Business.Services;
using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmAddParts : Form, IAddPartsView
    {
        private User _user;
        private AddPartsController _controller;

        public ComboBox Category
        {
            get
            {
                return cmbCategory;
            }
        }
        public string SearchName
        {
            get
            {
                return txtName.Text;
            }
        }

        public DataGridView DataGridView
        {
            get
            {
                return dataGridView;
            }
        }

        public ComboBox Color
        {
            get
            {
                return cmbColor;
            }
        }
        public int AddQty
        {
            get
            {
                return (int)nudAdd.Value;
            }
            set
            {
                nudAdd.Value = value;
            }
        }

        public frmAddParts(User user)
        {
            _user = user;
            _controller = new AddPartsController(this);
            InitializeComponent();
        }

        private void frmAddMOC_Load(object sender, EventArgs e)
        {
            _controller.Load();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _controller.Search();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _controller.Add();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _controller.PartSelected();
        }
    }
}
