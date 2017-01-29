using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IWishlistView : ISearchView
    {
        DataGridView DataGridView { get; }
        int RemoveQty { get; set; }
        int MaxRemoveQty { set; }
    }
}
