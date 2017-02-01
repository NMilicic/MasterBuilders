using Business.Exceptions;
using Business.Interfaces;
using Business.Services;
using Data.Domain;
using Desktop.BaseLib;
using System.Windows.Forms;


namespace Desktop.Controllers
{
    class RegisterController
    {
        private IRegisterView _view;
        private IView _parent;
        private IKorisnikService _userService;

        public RegisterController(IRegisterView view, IView parent)
        {
            _view = view;
            _parent = parent;
            _userService = new UserServices();
        }

        public void Register()
        {
            User korisnik = new User()
            {
                Email = _view.Email,
                Password = _view.Password,
                FirstName = _view.FirstName,
                LastName = _view.LastName
            };

            try
            {
                _userService.Register(korisnik);
            }
            catch (UserException)
            {
                MessageBox.Show("Username taken.");
                _view.Email = "";
                _view.Password = "";
                return;
            }

            MessageBox.Show("Account created.");
            _view.Close();
        }

        public void Close()
        {
            _parent.Show();
        }
    }
}
