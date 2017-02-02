using Desktop.BaseLib;
using Desktop.Controllers;
using System;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class frmRegister : Form, IRegisterView
    {
        private RegisterController _controller;
        
        public string Email { get { return txtEmail.Text; } set { txtEmail.Text = value; } }
        public string Password { get { return txtPassword.Text; } set { txtPassword.Text = value; } }
        public string FirstName => txtFirstName.Text;
        public string LastName => txtLastName.Text;
        
        public frmRegister(IView parent)
        {
            _controller = new RegisterController(this, parent);
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _controller.Register();
        }

        private void frmRegister_FormClosed(object sender, EventArgs e)
        {
            _controller.Close();
        }
    }
}
