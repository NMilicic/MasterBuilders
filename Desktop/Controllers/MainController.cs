using Data.Domain;
using Desktop.BaseLib;
using Desktop.Views;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class MainController
    {
        private IView _view;
        private User _user;
        private IView _parent;
        
        public MainController(IView view, User user, IView parent)
        {
            _view = view;
            _user = user;
            _parent = parent;
        }

        public void ShowDatabaseSets()
        {
            var newForm = new frmDatabaseSets(_user);
            ShowView(newForm);
        }

        public void ShowDatabaseParts()
        {
            var newForm = new frmDatabaseParts(_user);
            ShowView(newForm);
        }

        public void ShowInventorySets()
        {
            var newForm = new frmInventorySets(_user);
            ShowView(newForm);
        }

        public void ShowWishlist()
        {
            var newForm = new frmWishlist(_user);
            ShowView(newForm);
        }

        public void ShowMOCEdit()
        {
            //TODO MOCedit form
            /*
            var newForm = new frmEditMOC();
            ShowView(newForm);
            */
        }

        public void ShowMOCView()
        {
            var newForm = new frmMOC();
            ShowView(newForm);
        }

        public void ShowBA()
        {
            var newForm = new frmBuilderAssistant(_user);
            ShowView(newForm);
        }

        public void ShowCommunity()
        {
            //TODO community form
            /*
            var newForm = new frmCommunity();
            ShowView(newForm);
            */
        }

        public void ShowProfile()
        {
            //TODO profile form
            /*
            var newForm = new frmProfile();
            ShowView(newForm);
            */
        }

        public void Logout()
        {
            _view.Close();
        }

        public void Close()
        {
            _parent.Show();
        }

        private void ShowView(Form form)
        {
            var parent = (Form)_view;
            foreach (var c in parent.MdiChildren)
            {
                c.Close();
            }
            
            form.MdiParent = (Form) _view;
            form.Show();
        }
    }
}
