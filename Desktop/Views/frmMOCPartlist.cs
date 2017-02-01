using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmMOCPartlist : Form, IListView
    {
        private IEnumerable<MocPart> _parts;
        private MOCPartlistController _controller;

        public DataGridView DataGridView { get { return dataGridView; } }

        public frmMOCPartlist(IEnumerable<MocPart> parts)
        {
            _parts = parts;
            _controller = new MOCPartlistController(this);
            InitializeComponent();
        }

        private void frmMOCPartlist_Load(object sender, EventArgs e)
        {
            _controller.Load(_parts);
        }
    }
}
