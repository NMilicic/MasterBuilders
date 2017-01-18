using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILSetService : IService<LSet>
    {
        IQueryable<LSet> Search(string searchPattern);
        IQueryable<LSet> GetAllSetsWithBricks(List<int> bricksIds);
    }
}
