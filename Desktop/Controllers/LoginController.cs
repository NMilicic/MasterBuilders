using Business.Interfaces;
using Business.Services;
using Business.Exceptions;
using Data.Domain;
using System.Windows.Forms;
using Desktop.BaseLib;

namespace Desktop.Controllers
{
    class LoginController
    {
        private ILoginView _view;
        private IKorisnikService _userService;
        private IFormsFactory _factory;

        public LoginController(IFormsFactory factory, ILoginView view)
        {
            _factory = factory;
            _view = view;
            _userService = new UserServices();
        }

        public void Login()
        {
            var email = _view.Email;
            var password = _view.Password;

            User user;

            try
            {
                user = _userService.Login(email, password);
            } catch(UserException)
            {
                _view.Password = "";
                MessageBox.Show("Check E-mail and password.");
                return;
            }

            var newForm = _factory.createMainView(user, _view);
            _view.Email = "";
            _view.Password = "";
            _view.Hide();
            newForm.Show();
        }

        public void Register()
        {
            var newForm = _factory.createRegisterView(_view);
            _view.Email = "";
            _view.Password = "";
            _view.Hide();
            newForm.Show();
        }
    }
}
