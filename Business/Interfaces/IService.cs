using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IService<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
