using Data.Domain;
using Desktop.BaseLib;
using Desktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Controllers
{
    class MainController
    {
        private IView _view;
        private Korisnik _user;
        private IView _parent;
        
        public MainController(IView view, Korisnik user, IView parent)
        {
            _view = view;
            _user = user;
            _parent = parent;
        }

        public void Logout()
        {
            _view.Close();
        }

        public void ShowDatabaseSets()
        {
            var newForm = new frmDatabaseSets(_user);
            newForm.ShowDialog();
        }

        public void ShowDatabaseParts()
        {
            //TODO showdatabaseparts
        }

        public void ShowInventorySets()
        {
            var newForm = new frmInventorySets(_user);
            newForm.ShowDialog();
        }

        public void ShowInventoryParts()
        {
            //TODO showinventoryparts
        }

        public void Close()
        {
            _parent.Show();
        }
    }
}
