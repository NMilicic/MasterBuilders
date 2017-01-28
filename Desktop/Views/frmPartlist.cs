using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmPartlist : Form, IPartlistView
    {
        private IEnumerable<SetoviDijelovi> _parts;
        private PartlistController _controller;

        public DataGridView DataGridView { get { return dataGridView; } }

        public frmPartlist(IEnumerable<SetoviDijelovi> parts)
        {
            _parts = parts;
            _controller = new PartlistController(this);
            InitializeComponent();
        }

        private void frmPartlist_Load(object sender, EventArgs e)
        {
            _controller.Load(_parts);
            //dataGridView.DataSource = _data.ToList();
        }
    }
}
