﻿using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserSetService : IService<UserSet>
    {
        UserSet AddToInventory(int userId, int setId, int pieces);
        UserSet RemoveFromInventory(int userId, int setId, int pieces);
        UserSet MarkSetAsCompleted(int userId, int setId, int multiplier);
        IQueryable<LSet> GetAllForUser(int userId);
    }
}
