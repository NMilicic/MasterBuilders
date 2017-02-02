using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IDatabasePartsView : IView
    {
        ComboBox Category { get; }
        string SearchName { get; }

        DataGridView DataGridView { get; }
    }
}
