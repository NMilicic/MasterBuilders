﻿using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IKockiceService
    {
        IQueryable<Kockica> GetAll(int take = -1, int offset = 0);
        IQueryable<Kockica> GetAllForUser(int userId, int take = -1, int offset = 0);
    }
}
