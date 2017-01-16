using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IKorisnikService : IService<Korisnik>
    {
        Korisnik Login(string email, string zaporka);
        Korisnik Register(Korisnik newUser);
    }
}
