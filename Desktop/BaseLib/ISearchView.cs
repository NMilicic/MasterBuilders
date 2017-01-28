using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface ISearchView : IView
    {
        ComboBox Themes { get; }
        string SearchName { get; }
    }
}
