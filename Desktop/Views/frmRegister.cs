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
    public partial class frmRegister : Form, IRegisterView
    {
        private RegisterController _controller;
        private IView _parent;
        
        public string Email => txtEmail.Text;
        public string FirstName => txtFirstName.Text;
        public string LastName => txtLastName.Text;
        public string Password => txtPassword.Text;

        public frmRegister(IView parent)
        {
            _parent = parent;
            _controller = new RegisterController(this, parent);
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(frmRegister_FormClosed);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _controller.Register();
        }

        private void frmRegister_FormClosed(object sender, EventArgs e)
        {
            _parent.Show();
        }
    }
}
