using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmSetPartlist : Form, IListView
    {
        private IEnumerable<LSetPart> _parts;
        private SetPartlistController _controller;

        public DataGridView DataGridView { get { return dataGridView; } }

        public frmSetPartlist(IEnumerable<LSetPart> parts)
        {
            _parts = parts;
            _controller = new SetPartlistController(this);
            InitializeComponent();
        }

        private void frmPartlist_Load(object sender, EventArgs e)
        {
            _controller.Load(_parts);
        }
    }
}
