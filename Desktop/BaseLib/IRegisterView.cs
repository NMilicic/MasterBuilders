using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.BaseLib
{
    interface IRegisterView : IView
    {
        string Email { get; }
        string Password { get; }
        string FirstName { get; }
        string LastName { get; }
    }
}
