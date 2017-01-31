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
        IRepository<Part> kockicaRepository = new Repository<Part>();

        #region Default actions
        public IQueryable<Part> GetAll(int take = -1, int offset = 0)
        {
            var query = kockicaRepository.Query().Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public Part GetById(int id)
        {
            return kockicaRepository.GetById(id);
        }

        public void SaveOrUpdate(Part set)
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

        public IQueryable<Part> GetAllForUser(int userId, int take = -1, int offset = 0)
        {
            var query = kockicaRepository.Query().Where(x => x.Users.Any(u => u.Id == userId)).Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public IQueryable<Part> Search(string searchParameters, int take = -1, int offset = 0)
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
                    case SearchEnum.Category:
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
                if (fieldSplitted.Length > 1 && fieldSplitted[0].Length > 0 && fieldSplitted[1].Length > 0)
                {
                    searchDictionary.Add(fieldSplitted[0], fieldSplitted[1]);
                }
            }

            return searchDictionary;
        }

        private IQueryable<Part> FilterByName(string searchPattern, IQueryable<Part> query)
        {
            return query.Where(x => x.Name.Contains(searchPattern));
        }

        private IQueryable<Part> FilterByCategory(string searchPattern, IQueryable<Part> query)
        {
            return query.Where(x => x.Category.Name.Contains(searchPattern));
        }



        #endregion
    }
}
