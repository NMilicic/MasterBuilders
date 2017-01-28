using Business.Interfaces;
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
    public partial class frmLogin : Form, ILoginView
    {
        private LoginController _controller;

        public string Email { get => txtEmail.Text; set => txtEmail.Text = value; }
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }

        public frmLogin()
        {
            _controller = new LoginController(this);
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
