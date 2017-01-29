using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IDatabaseSetsView : IView
    {
        ComboBox Theme { get; }
        ComboBox Subtheme { get; }
        string SearchName { get; }

        DataGridView DataGridView { get; }

        int WishlistQty { get; set; }
        int InventoryQty { get; set; }
    }
}
