using Business.Enums;
using Business.Exceptions;
using Business.Interfaces;
using Data;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LSetService : ILSetService
    {
        IRepository<LSet> lSetRepository;
        IRepository<Wishlist> wishlistRepository;
        IRepository<User> userRepository;
        IRepository<UserLSet> inventoryRepository;
        IRepository<LSetPart> lSetPartRepository;

        public LSetService()
        {
            this.lSetRepository = new Repository<LSet>();
            this.wishlistRepository = new Repository<Wishlist>();
            this.userRepository = new Repository<User>();
            this.inventoryRepository = new Repository<UserLSet>();
            this.lSetPartRepository = new Repository<LSetPart>();
        }

        public LSetService(
            IRepository<LSet> lSetRepository,
            IRepository<Wishlist> wishlistRepository,
            IRepository<User> userRepository,
            IRepository<UserLSet> inventoryRepository,
            IRepository<LSetPart> lSetPartRepository
            )
        {
            this.lSetRepository = lSetRepository;
            this.wishlistRepository = wishlistRepository;
            this.userRepository = userRepository;
            this.inventoryRepository = inventoryRepository;
            this.lSetPartRepository = lSetPartRepository;
        }

        #region Default actions
        public IQueryable<LSet> GetAll(int take = -1, int offset = 0)
        {
            var query = lSetRepository.Query().Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public LSet GetById(int id)
        {
            return lSetRepository.GetById(id);
        }

        public void SaveOrUpdate(LSet set)
        {
            lSetRepository.Save(set);
        }

        public void Delete(int id)
        {
            var set = lSetRepository.GetById(id);
            if (set != null)
            {
                lSetRepository.Delete(set);
            }
            else
            {
                throw new DataException("Set not found!");
            }
        }

        #endregion

        #region Set specific actions

        public IQueryable<LSet> Search(string searchParameters, int take = -1, int offset = 0)
        {
            var query = lSetRepository.Query();
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
                    case SearchEnum.Description:
                        query = FilterByDescription(field.Value, query);
                        break;
                    case SearchEnum.NumberOfParts:
                        query = FilterByNumberOfParts(field.Value, query);
                        break;
                    case SearchEnum.ProductionYear:
                        query = FilterByYear(field.Value, query);
                        break;
                    case SearchEnum.Theme:
                        query = FilterByTheme(field.Value, query);
                        break;
                    case SearchEnum.BaseTheme:
                        query = FilterByBaseTheme(field.Value, query);
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

        public IQueryable<LSet> GetAllSetsWithBricks(List<int> bricksIds, int take = -1, int offset = 0)
        {
            var setoviDijelovi = lSetPartRepository.Query().Where(s => bricksIds.Contains(s.Part.Id));
            var sets = setoviDijelovi.Select(t => t.LSet);

            sets = sets.Skip(offset);
            if (take > 0)
                sets = sets.Take(take);

            return sets;
        }

        public List<LSet> BuilderAssistent(int userId)
        {
            var user = userRepository.GetById(userId);
            if (user != null)
            {
                var avaliableParts = user.LSets.Where(s => (s.Owned > s.Built)).SelectMany(x => x.LSet.LSetParts).ToList();
                foreach (var part in avaliableParts)
                {
                    var set = user.LSets.FirstOrDefault(s => s.LSet.Id == part.LSet.Id);
                    part.Number = (set.Owned - set.Built) * part.Number;
                }

                var possibleSets = lSetRepository.Query().Where(s => s.LSetParts.Count() > 0).ToList().Where(
                    s => s.LSetParts.All(
                        part => avaliableParts.Any(b => b.Color.Id == part.Color.Id) &&
                         avaliableParts.Any(b => b.Part.Id == part.Part.Id) &&
                         avaliableParts.Any(b => b.Number >= part.Number)))
                         .ToList();

                return possibleSets;
            }
            else
            {
                throw new UserException(UserException.UserExceptionsText(UserExceptionEnum.NotFound));
            }

        }
        #endregion

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

        private IQueryable<LSet> FilterByName(string searchPattern, IQueryable<LSet> query)
        {
            return query.Where(x => x.Name.Contains(searchPattern));
        }

        private IQueryable<LSet> FilterByDescription(string searchPattern, IQueryable<LSet> query)
        {
            return query.Where(x => x.Description.Contains(searchPattern));
        }

        private IQueryable<LSet> FilterByYear(string yearString, IQueryable<LSet> query)
        {
            var range = yearString.Split('-');
            if (range.Length > 1)
            {
                int lowerBound;
                Int32.TryParse(range[0], out lowerBound);

                int upperBound;
                if (!Int32.TryParse(range[1], out upperBound))
                {
                    upperBound = Int32.MaxValue;
                }

                return query.Where(x => x.ProductionYear >= lowerBound && x.ProductionYear <= upperBound);
                
            }
            return query;
        }

        private IQueryable<LSet> FilterByTheme(string theme, IQueryable<LSet> query)
        {
            return query.Where(x => x.Theme.Name == theme);
        }

        private IQueryable<LSet> FilterByBaseTheme(string theme, IQueryable<LSet> query)
        {
            return query.Where(x => x.Theme.BaseTheme != null && x.Theme.BaseTheme.Name == theme);
        }

        private IQueryable<LSet> FilterByNumberOfParts(string searchPattern, IQueryable<LSet> query)
        {
            var range = searchPattern.Split('-');
            if (range.Length > 1)
            {
                int lowerBound;
                Int32.TryParse(range[0], out lowerBound);

                int upperBound;
                if (!Int32.TryParse(range[1], out upperBound))
                {
                    upperBound = Int32.MaxValue;
                }

                return query.Where(x => x.NumberOfParts >= lowerBound && x.NumberOfParts <= upperBound);

            }
            return query;
        }

        #endregion
    }
}
