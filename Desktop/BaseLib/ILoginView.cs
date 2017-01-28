using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.BaseLib
{
    public interface ILoginView : IView
    {
        string Email { get; set; }
        string Password { get; set;  }
    }
}
