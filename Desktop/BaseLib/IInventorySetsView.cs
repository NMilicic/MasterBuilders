using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IInventorySetsView : IView
    {
        ComboBox Theme { get; }
        ComboBox Subtheme { get; }
        string SearchName { get; }

        DataGridView DataGridView { get; }

        int RemoveQty { get; set; }
        int AssembleQty { get; set; }
        int DisassembleQty { get; set; }
        int MaxAssembleQty { set; }
        int MaxDisassembleQty { set; }
        int MaxRemoveQty { set; }
    }
}
