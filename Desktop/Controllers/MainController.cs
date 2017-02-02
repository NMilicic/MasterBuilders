using Data.Domain;
using Desktop.BaseLib;
using System.Windows.Forms;

namespace Desktop.Controllers
{
    class MainController
    {
        private IFormsFactory _factory;
        private IView _view;
        private User _user;
        private IView _parent;
        
        public MainController(IFormsFactory factory, IView view, User user, IView parent)
        {
            _factory = factory;
            _view = view;
            _user = user;
            _parent = parent;
        }

        public void ShowDatabaseSets()
        {
            var newForm = _factory.createDatabaseSetsView(_user);
            ShowView((Form)newForm);
        }

        public void ShowDatabaseParts()
        {
            var newForm = _factory.createDatabasePartsView();
            ShowView((Form)newForm);
        }

        public void ShowInventorySets()
        {
            var newForm = _factory.createInventorySetsView(_user);
            ShowView((Form)newForm);
        }

        public void ShowWishlist()
        {
            var newForm = _factory.createWishlistView(_user);
            ShowView((Form)newForm);
        }

        public void ShowUserMOC()
        {
            var newForm = _factory.createUserMOCView(_user);
            ShowView((Form)newForm);
        }

        public void ShowMOCDatabase()
        {
            var newForm = _factory.createMOCView();
            ShowView((Form)newForm);
        }

        public void ShowBuilderAssistant()
        {
            var newForm = _factory.createBuilderAssistantView(_user);
            ShowView((Form)newForm);
        }

        public void ShowCommunity()
        {
            //TODO
        }

        public void ShowProfile()
        {
            //TODO
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
