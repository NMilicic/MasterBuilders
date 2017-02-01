using Business.Enums;
using Business.Exceptions;
using Business.Interfaces;
using Data;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class ThemeService : IThemeService
    {
        IRepository<Theme> themeRepository = new Repository<Theme>();

        #region Default actions
        public IQueryable<Theme> GetAll(int take = -1, int offset = 0)
        {
            var query = themeRepository.Query().OrderBy(x => x.Name).Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public Theme GetById(int id)
        {
            return themeRepository.GetById(id);
        }

        public void SaveOrUpdate(Theme set)
        {
            themeRepository.Save(set);
        }

        public void Delete(int id)
        {
            var set = themeRepository.GetById(id);
            if (set != null)
            {
                themeRepository.Delete(set);
            }
            else
            {
                throw new DataException("Theme not found!");
            }
        }

        #endregion

    }
}
