using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IInventorySetsView : ISearchView
    {
        DataGridView DataGridView { get; }
        int RemoveQty { get; set; }
        int AssembleQty { get; set; }
        int DisassembleQty { get; set; }
        int MaxAssembleQty { set; }
        int MaxDisassembleQty { set; }
        int MaxRemoveQty { set; }
    }
}
