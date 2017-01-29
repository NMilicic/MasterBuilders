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
        IQueryable<LSet> Search(string searchParameters, int take = -1, int offset = 0);
        IQueryable<LSet> GetAllSetsWithBricks(List<int> bricksIds, int take = -1, int offset = 0);
        List<LSet> BuilderAssistent(int userId);
    }
}
