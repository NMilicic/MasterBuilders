using Business.Interfaces;
using Business.Services;
using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmEditMOC : Form, IEditMOCView
    {
        private User _user;
        private EditMOCController _controller;

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

        public string Theme1
        {
            get
            {
                return txtTheme1.Text;
            }
            set
            {
                txtTheme1.Text = value;
            }
        }
        public string Theme2
        {
            get
            {
                return txtTheme2.Text;
            }
            set
            {
                txtTheme2.Text = value;
            }
        }
        public string Theme3
        {
            get
            {
                return txtTheme3.Text;
            }
            set
            {
                txtTheme3.Text = value;
            }
        }
        public string AddName
        {
            get
            {
                return txtAddName.Text;
            }
            set
            {
                txtAddName.Text = value;
            }
        }
        public string Description
        {
            get
            {
                return txtDescription.Text;
            }
            set
            {
                txtDescription.Text = value;
            }
        }

        public frmEditMOC(User user, Moc moc)
        {
            _user = user;
            _controller = new EditMOCController(this, moc, user);
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

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _controller.PartSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _controller.Add();
        }

        private void btnPartlist_Click(object sender, EventArgs e)
        {
            _controller.ShowPartlist();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _controller.SaveChanges();
        }
    }
}
