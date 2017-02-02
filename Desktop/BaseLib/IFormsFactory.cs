using Data.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Desktop.BaseLib
{
    public interface IFormsFactory
    {
        ILoginView createLoginView();
        IRegisterView createRegisterView(IView view);
        IDatabaseSetsView createDatabaseSetsView(User user);
        IDatabasePartsView createDatabasePartsView();
        IInventorySetsView createInventorySetsView(User user);
        IWishlistView createWishlistView(User user);
        IMOCView createMOCView();
        IUserMOCView createUserMOCView(User user);
        IEditMOCView createEditMOCView(User user, Moc moc);
        IBuilderAssistantView createBuilderAssistantView(User user);
        IView createMainView(User user, IView view);
        IListView createSetlistView(IQueryable<LSet> sets);
        IListView createSetPartlistView(IEnumerable<LSetPart> parts);
        IListView createMOCPartlistView(IEnumerable<MocPart> parts);
        IListView createEditMOCPartlistView(List<MocPart> parts);
        IView createPictureView(string url);
    }
}
