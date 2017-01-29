using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IInventoryPartsView : IView
    {
        ComboBox Category { get; }
        ComboBox Color { get; }
        string SearchName { get; }

        DataGridView DataGridView { get; }

        int RemoveQty { get; set; }
        int MaxRemoveQty { set; }
    }
}