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
    public partial class frmInventorySets : Form, IInventorySetsView
    {
        private User _user;
        private InventorySetsController _controller;

        public ComboBox Theme
        {
            get
            {
                return cmbTheme;
            }
        }
        public ComboBox Subtheme
        {
            get
            {
                return cmbSubtheme;
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
        public int AssembleQty
        {
            get
            {
                return (int)nudAssemble.Value;
            }
            set
            {
                nudAssemble.Value = value;
            }
        }
        public int DisassembleQty
        {
            get
            {
                return (int)nudDisassemble.Value;
            }
            set
            {
                nudDisassemble.Value = value;
            }
        }
        public int MaxRemoveQty
        {
            set
            {
                nudRemove.Maximum = value;
            }
        }
        public int MaxAssembleQty
        {
            set
            {
                nudAssemble.Maximum = value;
            }
        }
        public int MaxDisassembleQty
        {
            set
            {
                nudDisassemble.Maximum = value;
            }
        }
        
        public frmInventorySets(User user)
        {
            _user = user;
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _controller.RemoveSet();
        }

        private void btnAssemble_Click(object sender, EventArgs e)
        {
            _controller.AssembleSet();
        }

        private void btnDisassemble_Click(object sender, EventArgs e)
        {
            _controller.DisassembleSet();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _controller.SetSelected();
        }
    }
}
