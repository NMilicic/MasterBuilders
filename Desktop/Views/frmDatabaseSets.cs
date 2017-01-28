using Business.Interfaces;
using Business.Services;
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
    public partial class frmDatabaseParts : Form, IDatabaseSetsView
    {
        private Korisnik _user;
        private ILSetService _service;
        private DatabaseSetsController _controller;

        public DataGridView DataGridView { get => dataGridView; }
        public ComboBox Themes { get => cmbTheme; }
        public int WishlistQty { get => (int)nudWishlist.Value; }
        public int InventoryQty { get => (int)nudInventory.Value; }

        public frmDatabaseParts(Korisnik user)
        {
            _user = user;
            _service = new LSetService();
            _controller = new DatabaseSetsController(this, user);
            InitializeComponent();
        }

        private void frmDatabaseSets_Load(object sender, EventArgs e)
        {
            _controller.InitDataGridView();
            _controller.InitThemeComboBox();
        }

        private void cmbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.UpdateSubthemeComboBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _controller.Search();
        }

        private void btnWishlist_Click(object sender, EventArgs e)
        {
            _controller.AddToWishlist();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            _controller.AddToInventory();
        }

        private void btnPartlist_Click(object sender, EventArgs e)
        {
            _controller.ShowPartlist();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            _controller.DownloadInstructions();
        }
    }
}
