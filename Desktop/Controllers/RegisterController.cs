using Business.Exceptions;
using Business.Interfaces;
using Business.Services;
using Data.Domain;
using Desktop.BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Desktop.Controllers
{
    class RegisterController
    {
        private IRegisterView _view;
        private IView _parent;
        private IKorisnikService _service;

        public RegisterController(IRegisterView view, IView parent)
        {
            _view = view;
            _parent = parent;
            _service = new KorisnikServices();
        }

        public void Register()
        {
            Korisnik korisnik = new Korisnik()
            {
                Email = _view.Email,
                Zaporka = _view.Password,
                Ime = _view.FirstName,
                Prezime = _view.LastName
            };

            try
            {
                _service.Register(korisnik);
            }
            catch (KorisnikException)
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
