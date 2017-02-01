using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Web.Interfaces
{
    interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string Email { get; set; }
    }
}