using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IEditMOCView : IView
    {
        ComboBox Category { get; }
        string SearchName { get; }

        DataGridView DataGridView { get; }

        ComboBox Color { get; }
        int AddQty { get; set; }

        string AddName { get; set; }
        string Description { get; set; }
        string Theme1 { get; set; }
        string Theme2 { get; set; }
        string Theme3 { get; set; }
    }
}
