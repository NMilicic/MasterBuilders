﻿using Business.Interfaces;
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
        private User _user;
        private DatabasePartsController _controller;

        public ComboBox Category
        {
            get
            {
                return cmbCategory;
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

        public frmDatabaseParts(User user)
        {
            _user = user;
            _controller = new DatabasePartsController(this);
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
    }
}
