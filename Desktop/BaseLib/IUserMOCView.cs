using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IUserMOCView : IView
    {
        string SearchName { get; }

        DataGridView DataGridView { get; }
    }
}
