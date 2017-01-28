using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IPartlistView : IView
    {
        DataGridView DataGridView { get; }
    }
}
