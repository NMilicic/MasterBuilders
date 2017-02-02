using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmLogin : Form, ILoginView
    {
        private LoginController _controller;

        public string Email
        {
            get
            {
                return txtEmail.Text;
            }
            set
            {
                txtEmail.Text = value;
            }
        }
        public string Password
        {
            get

            { return txtPassword.Text; }
            set
            { txtPassword.Text = value; }
        }

        public frmLogin(IFormsFactory factory)
        {
            _controller = new LoginController(factory, this);
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _controller.Login();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _controller.Register();
        }
    }
}
