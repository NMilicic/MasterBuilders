﻿using Business.Interfaces;
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
    public partial class frmInventorySets : Form, IInventorySetsView
    {
        private Korisnik _user;
        private ILSetService _service;
        private InventorySetsController _controller;

        public DataGridView DataGridView { get => dataGridView; }
        public ComboBox Themes { get => cmbTheme; }
        public int WishlistQty { get => (int)nudWishlist.Value; set => nudWishlist.Value = value; }
        public int InventoryQty { get => (int)nudInventory.Value; set => nudInventory.Value = value; }
        public string SearchName { get => txtName.Text; }

        public frmInventorySets(Korisnik user)
        {
            _user = user;
            _service = new LSetService();
            _controller = new InventorySetsController(this, user);
            InitializeComponent();
        }

        private void frmInventorySets_Load(object sender, EventArgs e)
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