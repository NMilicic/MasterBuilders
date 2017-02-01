using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IAddPartsView : IView
    {
        ComboBox Category { get; }
        string SearchName { get; }

        DataGridView DataGridView { get; }

        ComboBox Color { get; }
        int AddQty { get; set; }
    }
}
