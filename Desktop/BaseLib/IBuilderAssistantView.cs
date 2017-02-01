using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IBuilderAssistantView : IView
    {
        ComboBox Theme { get; }
        ComboBox Subtheme { get; }

        DataGridView DataGridView { get; }
    }
}
