using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IWishlistView : IView
    {
        ComboBox Theme { get; }
        ComboBox Subtheme { get; }
        string SearchName { get; }

        DataGridView DataGridView { get; }

        int RemoveQty { get; set; }
        int MaxRemoveQty { set; }
    }
}
