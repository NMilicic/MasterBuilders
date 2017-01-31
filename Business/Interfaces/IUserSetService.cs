using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserSetService : IService<UserLSet>
    {
        UserLSet AddToInventory(int userId, int setId, int pieces);
        UserLSet RemoveFromInventory(int userId, int setId, int pieces);
        UserLSet MarkSetAsCompleted(int userId, int setId, int multiplier);
        IQueryable<UserLSet> GetAllForUser(int userId, int take = -1, int offset = 0);
        IQueryable<UserLSet> Search(int userId, string searchParameters, int take = -1, int offset = 0);
    }
}
