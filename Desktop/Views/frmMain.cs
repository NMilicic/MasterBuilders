using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmMain : Form, IView
    {
        private Korisnik _user;
        private IView _parent;
        private MainController _controller;

        public frmMain(Korisnik user, IView parent)
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

        private void menuInventorySets_Click(object sender, EventArgs e)
        {
            _controller.ShowInventorySets();
        }

        private void menuInventoryParts_Click(object sender, EventArgs e)
        {
            _controller.ShowInventoryParts();
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
