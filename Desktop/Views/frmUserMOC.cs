using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmUserMOC : Form, IUserMOCView
    {
        private UserMOCController _controller;

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

        public frmUserMOC(IFormsFactory factory, User user)
        {
            _controller = new UserMOCController(factory, this, user);
            InitializeComponent();
        }

        private void frmInventorySets_Load(object sender, EventArgs e)
        {
            _controller.Load();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _controller.Search();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _controller.AddMOC();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _controller.EditMOC();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _controller.RemoveMOC();
        }
    }
}
