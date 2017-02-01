using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IListView : IView
    {
        DataGridView DataGridView { get; }
    }
}
