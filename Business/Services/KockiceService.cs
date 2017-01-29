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
    public class KockiceService : IKockiceService
    {
        IRepository<Kockica> kockicaRepository = new Repository<Kockica>();

        #region Default actions
        public IQueryable<Kockica> GetAll(int take = -1, int offset = 0)
        {
            var query = kockicaRepository.Query().Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public Kockica GetById(int id)
        {
            return kockicaRepository.GetById(id);
        }

        public void SaveOrUpdate(Kockica set)
        {
            kockicaRepository.Save(set);
        }

        public void Delete(int id)
        {
            var set = kockicaRepository.GetById(id);
            if (set != null)
            {
                kockicaRepository.Delete(set);
            }
            else
            {
                throw new DataException("Kockica nije pronađena!");
            }
        }

        #endregion

        public IQueryable<Kockica> GetAllForUser(int userId, int take = -1, int offset = 0)
        {
            var query = kockicaRepository.Query().Where(x => x.Korisnik.Any(u => u.Id == userId)).Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public IQueryable<Kockica> Search(string searchParameters, int take = -1, int offset = 0)
        {
            var query = kockicaRepository.Query();
            var searchFields = ParseSearchParameters(searchParameters);
            foreach (var field in searchFields)
            {
                SearchEnum parsedEnum;
                Enum.TryParse(field.Key, true, out parsedEnum);
                switch (parsedEnum)
                {
                    case SearchEnum.Name:
                        query = FilterByName(field.Value, query);
                        break;
                    case SearchEnum.Kategorija:
                        query = FilterByCategory(field.Value, query);
                        break;
                    case SearchEnum.Error:
                        continue;
                }
            }

            query = query.Skip(offset);
            if (take > 0)
                query = query.Take(take);

            return query;
        }


        #region Private methods
        private Dictionary<string, string> ParseSearchParameters(string searchParameters)
        {
            var searchFields = searchParameters.Split(';');
            var searchDictionary = new Dictionary<string, string>();
            foreach (var field in searchFields)
            {
                var fieldSplitted = field.Split(':');
                if (fieldSplitted.Length > 1)
                {
                    searchDictionary.Add(fieldSplitted[0], fieldSplitted[1]);
                }
            }

            return searchDictionary;
        }

        private IQueryable<Kockica> FilterByName(string searchPattern, IQueryable<Kockica> query)
        {
            return query.Where(x => x.Ime.Contains(searchPattern));
        }

        private IQueryable<Kockica> FilterByCategory(string searchPattern, IQueryable<Kockica> query)
        {
            return query.Where(x => x.Kategorija.Contains(searchPattern));
        }



        #endregion
    }
}
