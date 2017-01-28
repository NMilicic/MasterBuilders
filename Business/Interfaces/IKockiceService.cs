using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    interface IKockiceService
    {
        IQueryable<Kockica> GetAll();
        IQueryable<Kockica> GetAllForUser(int userId);
    }
}
