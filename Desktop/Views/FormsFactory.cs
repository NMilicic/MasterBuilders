using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain;
using Desktop.BaseLib;

namespace Desktop.Views
{
    class FormsFactory : IFormsFactory
    {
        public IBuilderAssistantView createBuilderAssistantView(User user)
        {
            return new frmBuilderAssistant(user);
        }

        public IDatabasePartsView createDatabasePartsView()
        {
            return new frmDatabaseParts(this);
        }

        public IDatabaseSetsView createDatabaseSetsView(User user)
        {
            return new frmDatabaseSets(this, user);
        }

        public IListView createEditMOCPartlistView(List<MocPart> parts)
        {
            return new frmMOCPartlist(parts);
        }

        public IEditMOCView createEditMOCView(User user, Moc moc)
        {
            return new frmEditMOC(this, user, moc);
        }

        public IInventorySetsView createInventorySetsView(User user)
        {
            return new frmInventorySets(user);
        }

        public ILoginView createLoginView()
        {
            return new frmLogin(this);
        }

        public IView createMainView(User user, IView view)
        {
            return new frmMain(this, user, view);
        }

        public IListView createMOCPartlistView(IEnumerable<MocPart> parts)
        {
            return new frmMOCPartlist(parts);
        }

        public IMOCView createMOCView()
        {
            return new frmMOCDatabase(this);
        }

        public IView createPictureView(string url)
        {
            return new frmPicture(url);
        }

        public IRegisterView createRegisterView(IView view)
        {
            return new frmRegister(view);
        }

        public IListView createSetlistView(IQueryable<LSet> sets)
        {
            return new frmSetlist(sets);
        }

        public IListView createSetPartlistView(IEnumerable<LSetPart> parts)
        {
            return new frmSetPartlist(parts);
        }

        public IUserMOCView createUserMOCView(User user)
        {
            return new frmUserMOC(this, user);
        }

        public IWishlistView createWishlistView(User user)
        {
            return new frmWishlist(user);
        }
    }
}
