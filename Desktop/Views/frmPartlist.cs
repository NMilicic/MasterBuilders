using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmPartlist : Form
    {
        private IEnumerable<dynamic> _data;

        public DataGridView DataGridView { get { return dataGridView; } }

        public frmPartlist(IEnumerable<dynamic> data)
        {
            _data = data;
            InitializeComponent();
        }

        private void frmPartlist_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = _data.ToList();
            dataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
