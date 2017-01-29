using Business.Interfaces;
using Business.Services;
using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmDatabaseParts : Form, IDatabasePartsView
    {
        private Korisnik _user;
        private DatabasePartsController _controller;

        public ComboBox Category
        {
            get
            {
                return cmbCategory;
            }
        }
        public ComboBox Color
        {
            get
            {
                return cmbColor;
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

        /*
        public int WishlistQty
        {
            get
            {
                return (int)nudWishlist.Value;
            }
            set
            {
                nudWishlist.Value = value;
            }
        }
        */
        public int InventoryQty
        {
            get
            {
                return (int)nudInventory.Value;
            }
            set
            {
                nudInventory.Value = value;
            }
        }
        
        public frmDatabaseParts(Korisnik user)
        {
            _user = user;
            _controller = new DatabasePartsController(this, user);
            InitializeComponent();
        }

        private void frmDatabaseParts_Load(object sender, EventArgs e)
        {
            _controller.Load();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _controller.Search();
        }

        private void btnWishlist_Click(object sender, EventArgs e)
        {
            //_controller.AddToWishlist();
        }
        
        private void btnInventory_Click(object sender, EventArgs e)
        {
            _controller.AddToInventory();
        }
        
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _controller.PartSelected();
        }
    }
}
