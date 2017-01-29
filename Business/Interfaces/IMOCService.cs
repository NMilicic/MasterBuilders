﻿using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMOCService
    {
        IQueryable<Moc> GetAllByAuthor(int authorId, int take = -1, int offset = 0);
        Moc AddMoc(Moc newMoc);
        Moc AddDijeloviMoc(int mocId, List<MocDijelovi> dijelovi);
    }
}
