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
    public class WishlistService : IWishlistService
    {
        IRepository<Wishlist> wishlistRepository = new Repository<Wishlist>();
        IRepository<User> userRepository = new Repository<User>();
        IRepository<LSet> lSetRepository = new Repository<LSet>();

        public IQueryable<Wishlist> GetAll(int take = -1, int offset = 0)
        {
            var query = wishlistRepository.Query().Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public Wishlist GetById(int id)
        {
            return wishlistRepository.GetById(id);
        }

        public void SaveOrUpdate(Wishlist wishlist)
        {
            wishlistRepository.Save(wishlist);
        }

        public void Delete(int id)
        {
            var wishlist = wishlistRepository.GetById(id);
            if (wishlist != null)
            {
                wishlistRepository.Delete(wishlist);
            }
            else
            {
                throw new DataException("Wishlist not found!");
            }
        }

        public IQueryable<Wishlist> GetAllSetsFromWishlistForUser(int userId, int take = -1, int offset = 0)
        {
            var query = wishlistRepository.Query().Where(w => w.User.Id == userId).Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public Wishlist AddSetToWishlistForUser(int userId, int setId, int pieces)
        {

            var user = userRepository.GetById(userId);
            if (user != null)
            {
                var dbSet = lSetRepository.GetById(setId);
                if (dbSet != null)
                {
                    var existingWishListItem = wishlistRepository.Query().FirstOrDefault(x => x.User.Id == userId && x.LSet.Id == setId);
                    if (existingWishListItem == null)
                    {
                        var wishListForSave = new Wishlist()
                        {
                            User = user,
                            LSet = dbSet,
                            Number = pieces
                        };
                        wishlistRepository.Save(wishListForSave);

                        return wishListForSave;
                    }
                    else
                    {
                        existingWishListItem.Number += pieces;
                        wishlistRepository.Save(existingWishListItem);

                        return existingWishListItem;
                    }
                }
                else
                {
                    throw new DataException("Set not found!");
                }
            }

            throw new UserException(UserException.UserExceptionsText(UserExceptionEnum.NotFound));


        }

        public Wishlist RemoveSetFromWishlistForUser(int userId, int setId, int pieces)
        {
            var user = userRepository.GetById(userId);
            if (user != null)
            {
                var dbSet = lSetRepository.GetById(setId);
                if (dbSet != null)
                {
                    var existingWishlistItem = wishlistRepository.Query().FirstOrDefault(x => x.User.Id == userId && x.LSet.Id == setId);

                    if (existingWishlistItem == null)
                    {
                        throw new DataException("Set is not in wishlist!");
                    }
                    else
                    {
                        if (existingWishlistItem.Number > pieces)
                        {
                            existingWishlistItem.Number -= pieces;
                            wishlistRepository.Save(existingWishlistItem);
                        }
                        else
                        {
                            wishlistRepository.Delete(existingWishlistItem);
                        }

                        return existingWishlistItem;
                    }
                }
                else
                {
                    throw new DataException("Set not found!");
                }
            }

            throw new UserException(UserException.UserExceptionsText(UserExceptionEnum.NotFound));
        }

        public IQueryable<Wishlist> Search(int userId ,string searchParameters, int take = -1, int offset = 0)
        {
            var query = wishlistRepository.Query().Where(w => w.User.Id == userId);
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
                    case SearchEnum.Owned:
                        query = FilterByOwned(field.Value, query);
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

        private IQueryable<Wishlist> FilterByName(string searchPattern, IQueryable<Wishlist> query)
        {
            return query.Where(x => x.LSet.Name.Contains(searchPattern));
        }

        private IQueryable<Wishlist> FilterByDescription(string searchPattern, IQueryable<Wishlist> query)
        {
            return query.Where(x => x.LSet.Description.Contains(searchPattern));
        }

        private IQueryable<Wishlist> FilterByYear(string yearString, IQueryable<Wishlist> query)
        {
            int year;
            var parseYear = Int32.TryParse(yearString, out year);

            return parseYear ? query.Where(x => x.LSet.ProductionYear == year) : query;
        }

        private IQueryable<Wishlist> FilterByTheme(string theme, IQueryable<Wishlist> query)
        {
            return query.Where(x => x.LSet.Theme.Name == theme);
        }

        private IQueryable<Wishlist> FilterByBaseTheme(string theme, IQueryable<Wishlist> query)
        {
            return query.Where(x => x.LSet.Theme.BaseTheme != null && x.LSet.Theme.BaseTheme.Name == theme);
        }

        private IQueryable<Wishlist> FilterByNumberOfParts(string searchPattern, IQueryable<Wishlist> query)
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

        private IQueryable<Wishlist> FilterByOwned(string searchPattern, IQueryable<Wishlist> query)
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
                    return query.Where(x => x.Number >= lowerBound && x.Number <= upperBound);
                }
            }
            return query;
        }

        #endregion
    }
}
