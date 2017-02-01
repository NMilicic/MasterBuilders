using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.BaseLib
{
    public interface IMOCView : IView
    {
        string SearchName { get; }
        string Theme { get; }
        string Author { get; }
        string SearchYearFrom { get; }
        string SearchYearTo { get; }
        string SearchPartsFrom { get; }
        string SearchPartsTo { get; }

        DataGridView DataGridView { get; }
    }
}
