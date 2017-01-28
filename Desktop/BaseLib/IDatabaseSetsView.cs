using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IDatabaseSetsView : ISearchView
    {
        DataGridView DataGridView { get; }
        int WishlistQty { get; set; }
        int InventoryQty { get; set; }
    }
}
