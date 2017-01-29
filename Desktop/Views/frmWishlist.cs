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
    public partial class frmWishlist : Form, IWishlistView
    {
        private Korisnik _user;
        private WishlistController _controller;

        public DataGridView DataGridView
        {
            get
            {
                return dataGridView;
            }
        }
        public ComboBox Themes
        {
            get
            {
                return cmbTheme;
            }
        }
        public int RemoveQty
        {
            get
            {
                return (int)nudRemove.Value;
            }
            set
            {
                nudRemove.Value = value;
            }
        }
        public int MaxRemoveQty
        {
            set
            {
                nudRemove.Maximum = value;
            }
        }
        public string SearchName
        {
            get
            {
                return txtName.Text;
            }
        }

        public frmWishlist(Korisnik user)
        {
            _user = user;
            _controller = new WishlistController(this, user);
            InitializeComponent();
        }

        private void frmWishlist_Load(object sender, EventArgs e)
        {
            _controller.Load();
        }

        private void cmbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.UpdateSubthemeComboBox();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _controller.Search();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _controller.RemoveSet();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _controller.SetSelected();
        }
    }
}
