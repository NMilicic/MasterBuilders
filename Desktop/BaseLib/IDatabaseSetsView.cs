using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IDatabaseSetsView : IView
    {
        DataGridView DataGridView { get; }
        ComboBox Themes { get; }
        int WishlistQty { get; set; }
        int InventoryQty { get; set; }
        string SearchName { get; }
    }
}
