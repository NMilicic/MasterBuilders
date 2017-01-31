using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IKockiceService: IService<Part>
    {
        IQueryable<Part> GetAllForUser(int userId, int take = -1, int offset = 0);
        IQueryable<Part> Search(string searchParameters, int take = -1, int offset = 0);
    }
}
