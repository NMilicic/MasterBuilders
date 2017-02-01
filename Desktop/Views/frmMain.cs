using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmMain : Form, IView
    {
        private User _user;
        private IView _parent;
        private MainController _controller;

        public frmMain(User user, IView parent)
        {
            _user = user;
            _parent = parent;
            _controller = new MainController(this, user, parent);
            InitializeComponent();
        }

        private void menuDatabaseSets_Click(object sender, EventArgs e)
        {
            _controller.ShowDatabaseSets();
        }

        private void menuDatabaseParts_Click(object sender, EventArgs e)
        {
            _controller.ShowDatabaseParts();
        }

        private void menuInventory_Click(object sender, EventArgs e)
        {
            _controller.ShowInventorySets();
        }
        private void wishlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ShowWishlist();
        }

        private void menuBA_Click(object sender, EventArgs e)
        {
            _controller.ShowBA();
        }

        private void menuMOCView_Click(object sender, EventArgs e)
        {
            _controller.ShowMOCView();
        }

        private void menuMOCEdit_Click(object sender, EventArgs e)
        {
            _controller.ShowMOCEdit();
        }

        private void menuCommunity_Click(object sender, EventArgs e)
        {
            _controller.ShowCommunity();
        }

        private void menuProfile_Click(object sender, EventArgs e)
        {
            _controller.ShowProfile();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            _controller.Logout();
        }

        private void frmMain_FormClosed(object sender, EventArgs e)
        {
            _controller.Close();
        }
    }
}
