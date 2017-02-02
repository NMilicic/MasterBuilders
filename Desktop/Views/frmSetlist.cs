using Data.Domain;
using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmSetlist : Form, IListView
    {
        private IQueryable<LSet> _sets;
        private SetlistController _controller;

        public DataGridView DataGridView { get { return dataGridView; } }

        public frmSetlist(IQueryable<LSet> sets)
        {
            _sets = sets;
            _controller = new SetlistController(this);
            InitializeComponent();
        }

        private void frmSetlist_Load(object sender, EventArgs e)
        {
            _controller.Load(_sets);
        }
    }
}
