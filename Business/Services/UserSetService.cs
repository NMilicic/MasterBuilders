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
    public class UserSetService : IUserSetService
    {
        IRepository<UserLSet> inventroyRepository = new Repository<UserLSet>();
        IRepository<LSet> setRepository = new Repository<LSet>();
        IRepository<Wishlist> wishlistRepository = new Repository<Wishlist>();
        IRepository<User> korisnikRepository = new Repository<User>();

        #region Default actions
        public IQueryable<UserLSet> GetAll(int take, int offset)
        {
            var query = inventroyRepository.Query().Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public UserLSet GetById(int id)
        {
            return inventroyRepository.GetById(id);
        }

        public void SaveOrUpdate(UserLSet set)
        {
            inventroyRepository.Save(set);
        }

        public void Delete(int id)
        {
            var set = inventroyRepository.GetById(id);
            if (set != null)
            {
                inventroyRepository.Delete(set);
            }
            else
            {
                throw new DataException("User Set nije pronađen!");
            }
        }

        #endregion

        public IQueryable<UserLSet> GetAllForUser(int userId, int take = -1, int offset = 0)
        {
            var query = inventroyRepository.Query().Where(s => s.User.Id == userId).Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public UserLSet AddToInventory(int userId, int setId, int pieces)
        {
            var user = korisnikRepository.GetById(userId);
            if (user != null)
            {
                var dbSet = setRepository.GetById(setId);
                if (dbSet != null)
                {
                    var existingWishListItem = wishlistRepository.Query().FirstOrDefault(x => x.User.Id == userId && x.LSet.Id == setId);

                    if (existingWishListItem != null)
                    {
                        existingWishListItem.Number -= pieces;
                        wishlistRepository.Save(existingWishListItem);
                    }
                    var existingInventroyItem = inventroyRepository.Query().FirstOrDefault(x => x.User.Id == userId && x.LSet.Id == setId);

                    if (existingInventroyItem == null)
                    {
                        var inventoryForSave = new UserLSet()
                        {
                            User = user,
                            LSet = dbSet,
                            Built = 0,
                            Owned = pieces
                        };
                        inventroyRepository.Save(inventoryForSave);

                        return inventoryForSave;
                    }
                    else
                    {
                        existingInventroyItem.Owned += pieces;
                        inventroyRepository.Save(existingInventroyItem);

                        return existingInventroyItem;
                    }
                }
                else
                {
                    throw new DataException("Set not found!");
                }
            }

            throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.NotFound));
        }

        public UserLSet RemoveFromInventory(int userId, int setId, int pieces)
        {
            var user = korisnikRepository.GetById(userId);
            if (user != null)
            {
                var dbSet = setRepository.GetById(setId);
                if (dbSet != null)
                {
                    var existingInventroyItem = inventroyRepository.Query().FirstOrDefault(x => x.User.Id == userId && x.LSet.Id == setId);

                    if (existingInventroyItem == null)
                    {
                        throw new DataException("Set ne postoji u inventaru!");
                    }
                    else
                    {
                        if (existingInventroyItem.Owned > pieces)
                        {
                            existingInventroyItem.Owned -= pieces;
                            if(existingInventroyItem.Owned < existingInventroyItem.Built)
                            {
                                existingInventroyItem.Built = existingInventroyItem.Owned;
                            }
                            inventroyRepository.Save(existingInventroyItem);
                        }
                        else
                        {
                            inventroyRepository.Delete(existingInventroyItem);
                        }

                        return existingInventroyItem;
                    }
                }
                else
                {
                    throw new DataException("Set not found!");
                }
            }

            throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.NotFound));
        }

        public UserLSet MarkSetAsCompleted(int userId, int setId, int multiplier)
        {
            var user = korisnikRepository.GetById(userId);
            if (user != null)
            {
                var dbSet = setRepository.GetById(setId);
                if (dbSet != null)
                {
                    var existingInventroyItem = inventroyRepository.Query().FirstOrDefault(x => x.User.Id == userId && x.LSet.Id == setId);

                    if (existingInventroyItem == null)
                    {
                        throw new DataException("Set ne postoji u inventaru!");
                    }
                    else
                    {
                        if (existingInventroyItem.Owned >= (existingInventroyItem.Built + multiplier) && existingInventroyItem.Built + multiplier >= 0)
                        {
                            existingInventroyItem.Built += multiplier;
                            inventroyRepository.Save(existingInventroyItem);

                            return existingInventroyItem;
                        }

                        throw new DataException("You don't have that much sets");
                    }
                }
                else
                {
                    throw new DataException("Set not found!");
                }
            }

            throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.NotFound));
        }

        public IQueryable<UserLSet> Search(int userId, string searchParameters, int take = -1, int offset = 0)
        {
            var query = inventroyRepository.Query().Where(s => s.User.Id == userId);
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
                        query = FilterByBrojKockica(field.Value, query);
                        break;
                    case SearchEnum.ProductionYear:
                        query = FilterByYear(field.Value, query);
                        break;
                    case SearchEnum.Theme:
                        query = FilterByTema(field.Value, query);
                        break;
                    case SearchEnum.BaseTheme:
                        query = FilterByNadTema(field.Value, query);
                        break;
                    case SearchEnum.Owned:
                        query = FilterByBrojKomada(field.Value, query);
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

        private IQueryable<UserLSet> FilterByName(string searchPattern, IQueryable<UserLSet> query)
        {
            return query.Where(x => x.LSet.Name.Contains(searchPattern));
        }

        private IQueryable<UserLSet> FilterByDescription(string searchPattern, IQueryable<UserLSet> query)
        {
            return query.Where(x => x.LSet.Description.Contains(searchPattern));
        }

        private IQueryable<UserLSet> FilterByYear(string yearString, IQueryable<UserLSet> query)
        {
            int year;
            var parseYear = Int32.TryParse(yearString, out year);

            return parseYear ? query.Where(x => x.LSet.ProductionYear == year) : query;
        }

        private IQueryable<UserLSet> FilterByTema(string tema, IQueryable<UserLSet> query)
        {
            //return query.Where(x => x.Set.Tema.ImeTema == tema || (x.Set.Tema.NadTema != null && x.Set.Tema.NadTema.ImeTema == tema));
            return query.Where(x => x.LSet.Theme.Name == tema);
        }

        private IQueryable<UserLSet> FilterByNadTema(string tema, IQueryable<UserLSet> query)
        {
            return query.Where(x => x.LSet.Theme.BaseTheme != null && x.LSet.Theme.BaseTheme.Name == tema);
        }

        private IQueryable<UserLSet> FilterByBrojKockica(string searchPattern, IQueryable<UserLSet> query)
        {
            var range = searchPattern.Split('-');
            if (range.Length > 1)
            {
                int lowerBound;
                var parseLowerBound = Int32.TryParse(range[0], out lowerBound);
                int upperBound;
                var parseUpperBound = Int32.TryParse(range[1], out upperBound);

                if (parseLowerBound && parseUpperBound)
                {
                    return query.Where(x => x.LSet.NumberOfParts >= lowerBound && x.LSet.NumberOfParts <= upperBound);
                }
            }
            return query;
        }

        private IQueryable<UserLSet> FilterByBrojKomada(string searchPattern, IQueryable<UserLSet> query)
        {
            var range = searchPattern.Split('-');
            if (range.Length > 1)
            {
                int lowerBound;
                var parseLowerBound = Int32.TryParse(range[0], out lowerBound);
                int upperBound;
                var parseUpperBound = Int32.TryParse(range[1], out upperBound);

                if (parseLowerBound && parseUpperBound)
                {
                    return query.Where(x => x.Owned >= lowerBound && x.Owned <= upperBound);
                }
            }
            return query;
        }

        #endregion
    }
}
