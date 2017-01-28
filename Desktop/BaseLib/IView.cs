using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.BaseLib
{
    public interface IView
    {
        void Show();
        void Hide();
        void Close();
    }
}
