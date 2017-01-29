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
        IRepository<UserSet> inventroyRepository = new Repository<UserSet>();
        IRepository<LSet> setRepository = new Repository<LSet>();
        IRepository<Wishlist> wishlistRepository = new Repository<Wishlist>();
        IRepository<Korisnik> korisnikRepository = new Repository<Korisnik>();

        #region Default actions
        public IQueryable<UserSet> GetAll(int take, int offset)
        {
            var query = inventroyRepository.Query().Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public UserSet GetById(int id)
        {
            return inventroyRepository.GetById(id);
        }

        public void SaveOrUpdate(UserSet set)
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

        public IQueryable<UserSet> GetAllForUser(int userId, int take = -1, int offset = 0)
        {
            var query = inventroyRepository.Query().Where(s => s.Korisnik.Id == userId).Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public UserSet AddToInventory(int userId, int setId, int pieces)
        {
            var user = korisnikRepository.GetById(userId);
            if (user != null)
            {
                var dbSet = setRepository.GetById(setId);
                if (dbSet != null)
                {
                    var existingWishListItem = wishlistRepository.Query().FirstOrDefault(x => x.Korisnik.Id == userId && x.Set.Id == setId);

                    if (existingWishListItem != null)
                    {
                        existingWishListItem.Komada -= pieces;
                        wishlistRepository.Save(existingWishListItem);
                    }
                    var existingInventroyItem = inventroyRepository.Query().FirstOrDefault(x => x.Korisnik.Id == userId && x.Set.Id == setId);

                    if (existingInventroyItem == null)
                    {
                        var inventoryForSave = new UserSet()
                        {
                            Korisnik = user,
                            Set = dbSet,
                            Slozeno = 0,
                            Komada = pieces
                        };
                        inventroyRepository.Save(inventoryForSave);

                        return inventoryForSave;
                    }
                    else
                    {
                        existingInventroyItem.Komada += pieces;
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

        public UserSet RemoveFromInventory(int userId, int setId, int pieces)
        {
            var user = korisnikRepository.GetById(userId);
            if (user != null)
            {
                var dbSet = setRepository.GetById(setId);
                if (dbSet != null)
                {
                    var existingInventroyItem = inventroyRepository.Query().FirstOrDefault(x => x.Korisnik.Id == userId && x.Set.Id == setId);

                    if (existingInventroyItem == null)
                    {
                        throw new DataException("Set ne postoji u inventaru!");
                    }
                    else
                    {
                        if (existingInventroyItem.Komada > pieces)
                        {
                            existingInventroyItem.Komada -= pieces;
                            if(existingInventroyItem.Komada < existingInventroyItem.Slozeno)
                            {
                                existingInventroyItem.Slozeno = existingInventroyItem.Komada;
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

        public UserSet MarkSetAsCompleted(int userId, int setId, int multiplier)
        {
            var user = korisnikRepository.GetById(userId);
            if (user != null)
            {
                var dbSet = setRepository.GetById(setId);
                if (dbSet != null)
                {
                    var existingInventroyItem = inventroyRepository.Query().FirstOrDefault(x => x.Korisnik.Id == userId && x.Set.Id == setId);

                    if (existingInventroyItem == null)
                    {
                        throw new DataException("Set ne postoji u inventaru!");
                    }
                    else
                    {
                        if (existingInventroyItem.Komada >= (existingInventroyItem.Slozeno + multiplier) && existingInventroyItem.Slozeno + multiplier >= 0)
                        {
                            existingInventroyItem.Slozeno += multiplier;
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

        public IQueryable<UserSet> Search(int userId, string searchParameters, int take = -1, int offset = 0)
        {
            var query = inventroyRepository.Query().Where(s => s.Korisnik.Id == userId);
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
                    case SearchEnum.Opis:
                        query = FilterByDescription(field.Value, query);
                        break;
                    case SearchEnum.BrojKockica:
                        query = FilterByBrojKockica(field.Value, query);
                        break;
                    case SearchEnum.GodinaProizvodnje:
                        query = FilterByYear(field.Value, query);
                        break;
                    case SearchEnum.Tema:
                        query = FilterByTema(field.Value, query);
                        break;
                    case SearchEnum.Komada:
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

        private IQueryable<UserSet> FilterByName(string searchPattern, IQueryable<UserSet> query)
        {
            return query.Where(x => x.Set.Ime.Contains(searchPattern));
        }

        private IQueryable<UserSet> FilterByDescription(string searchPattern, IQueryable<UserSet> query)
        {
            return query.Where(x => x.Set.Opis.Contains(searchPattern));
        }

        private IQueryable<UserSet> FilterByYear(string yearString, IQueryable<UserSet> query)
        {
            int year;
            var parseYear = Int32.TryParse(yearString, out year);

            return parseYear ? query.Where(x => x.Set.GodinaProizvodnje == year) : query;
        }

        private IQueryable<UserSet> FilterByTema(string tema, IQueryable<UserSet> query)
        {
            return query.Where(x => x.Set.Tema.ImeTema == tema || (x.Set.Tema.NadTema != null && x.Set.Tema.NadTema.ImeTema == tema));
        }

        private IQueryable<UserSet> FilterByBrojKockica(string searchPattern, IQueryable<UserSet> query)
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
                    return query.Where(x => x.Set.DijeloviBroj >= lowerBound && x.Set.DijeloviBroj <= upperBound);
                }
            }
            return query;
        }

        private IQueryable<UserSet> FilterByBrojKomada(string searchPattern, IQueryable<UserSet> query)
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
                    return query.Where(x => x.Komada >= lowerBound && x.Komada <= upperBound);
                }
            }
            return query;
        }

        #endregion
    }
}
