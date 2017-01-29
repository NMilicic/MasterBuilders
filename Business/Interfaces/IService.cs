using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IService<T>
    {
        IQueryable<T> GetAll(int take = -1, int offset = 0);
        T GetById(int id);
        void SaveOrUpdate(T obj);
        void Delete(int id);
    }
}
