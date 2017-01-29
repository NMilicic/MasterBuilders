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
    public partial class frmInventoryParts : Form, IInventoryPartsView
    {
        private Korisnik _user;
        private InventoryPartsController _controller;

        public DataGridView DataGridView
        {
            get
            {
                return dataGridView;
            }
        }
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

        public frmInventoryParts(Korisnik user)
        {
            _user = user;
            _controller = new InventoryPartsController(this, user);
            InitializeComponent();
        }

        private void frmInventoryParts_Load(object sender, EventArgs e)
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
            _controller.RemovePart();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _controller.SetSelected();
        }
    }
}
