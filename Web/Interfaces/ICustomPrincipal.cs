using System.Security.Principal;

namespace Web.Interfaces
{
    interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string Email { get; set; }
    }
}