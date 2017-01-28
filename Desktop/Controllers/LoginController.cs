using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Services;
using Business.Exceptions;
using Data.Domain;
using Desktop.Views;
using System.Windows.Forms;
using Desktop.BaseLib;

namespace Desktop.Controllers
{
    class LoginController
    {
        private ILoginView _view;
        private IKorisnikService _service;

        public LoginController(ILoginView view)
        {
            _view = view;
            _service = new KorisnikServices();
        }

        public void Login()
        {
            var email = _view.Email;
            var password = _view.Password;

            Korisnik user;

            try
            {
                user = _service.Login(email, password);
            } catch(KorisnikException)
            {
                _view.Password = "";
                MessageBox.Show("Check E-mail and password.");
                return;
            }

            var newForm = new frmMain(user, _view);
            _view.Email = "";
            _view.Password = "";
            _view.Hide();
            newForm.Show();
        }

        public void Register()
        {
            var newForm = new frmRegister(_view);
            _view.Email = "";
            _view.Password = "";
            _view.Hide();
            newForm.Show();
        }
    }
}
