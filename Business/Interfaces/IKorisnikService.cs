using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IKorisnikService : IService<User>
    {
        User Login(string email, string zaporka);
        User Register(User newUser);
    }
}
