using Business.Interfaces;
using Business.Services;
using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmMOCDatabase : Form, IMOCView
    {
        private MOCController _controller;

        public string SearchName
        {
            get
            {
                return txtName.Text;
            }
        }
        public string Theme
        {
            get
            {
                return txtTheme.Text;
            }
        }
        public string Author
        {
            get
            {
                return txtAuthor.Text;
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

        public frmMOCDatabase()
        {
            _controller = new MOCController(this);
            InitializeComponent();
        }

        private void frmMOC_Load(object sender, EventArgs e)
        {
            _controller.Load();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _controller.Search();
        }

        private void btnPartlist_Click(object sender, EventArgs e)
        {
            _controller.ShowPartlist();
        }

        private void frmMOC_Resize(object sender, EventArgs e)
        {
            if (this.Width < 1200)
            {
                this.btnSearch.Height = 50;
                this.searchPanel.SetFlowBreak(this.txtAuthor, true);
            } else
            {
                this.btnSearch.Height = 25;
                this.searchPanel.SetFlowBreak(this.txtAuthor, false);
            }
        }
    }
}
