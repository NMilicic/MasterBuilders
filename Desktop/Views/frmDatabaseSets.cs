using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmDatabaseSets : Form, IDatabaseSetsView
    {
        private DatabaseSetsController _controller;

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
        public string SearchYearFrom
        {
            get
            {
                return txtYearFrom.Text;
            }
        }
        public string SearchYearTo
        {
            get
            {
                return txtYearTo.Text;
            }
        }
        public string SearchPartsFrom
        {
            get
            {
                return txtPartsFrom.Text;
            }
        }
        public string SearchPartsTo
        {
            get
            {
                return txtPartsTo.Text;
            }
        }

        public DataGridView DataGridView
        {
            get
            {
                return dataGridView;
            }
        }

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
        
        public frmDatabaseSets(IFormsFactory factory, User user)
        {
            _controller = new DatabaseSetsController(factory, this, user);
            InitializeComponent();
        }

        private void frmDatabaseSets_Load(object sender, EventArgs e)
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
        
        private void btnPicture_Click(object sender, EventArgs e)
        {
            _controller.ShowPicture();
        }

        private void btnPartlist_Click(object sender, EventArgs e)
        {
            _controller.ShowPartlist();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            _controller.DownloadInstructions();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _controller.SetSelected();
        }

        private void frmDatabaseSets_Resize(object sender, EventArgs e)
        {
            if (Width < 1200)
            {
                btnSearch.Height = 50;
                searchPanel.SetFlowBreak(cmbSubtheme, true);
            } else
            {
                btnSearch.Height = 25;
                searchPanel.SetFlowBreak(cmbSubtheme, false);
            }
        }
    }
}
