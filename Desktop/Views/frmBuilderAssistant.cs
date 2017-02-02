using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmBuilderAssistant : Form, IBuilderAssistantView
    {
        private BuilderAssistantController _controller;

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
        
        public DataGridView DataGridView
        {
            get
            {
                return dataGridView;
            }
        }

        public frmBuilderAssistant(User user)
        {
            _controller = new BuilderAssistantController(this, user);
            InitializeComponent();
        }

        private void frmBuilderAssistant_Load(object sender, EventArgs e)
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            _controller.DownloadInstructions();
        }
    }
}
