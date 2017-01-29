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
        IRepository<Korisnik> korisnikRepository = new Repository<Korisnik>();
        IRepository<LSet> setRepository = new Repository<LSet>();

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
                throw new DataException("Lista želja nije pronađena!");
            }
        }

        public IQueryable<Wishlist> GetAllSetsFromWishlistForUser(int userId, int take = -1, int offset = 0)
        {
            var query = wishlistRepository.Query().Where(w => w.Korisnik.Id == userId).Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public Wishlist AddSetToWishlistForUser(int userId, int setId, int pieces)
        {

            var user = korisnikRepository.GetById(userId);
            if (user != null)
            {
                var dbSet = setRepository.GetById(setId);
                if (dbSet != null)
                {
                    var existingWishListItem = wishlistRepository.Query().FirstOrDefault(x => x.Korisnik.Id == userId && x.Set.Id == setId);
                    if (existingWishListItem == null)
                    {
                        var wishListForSave = new Wishlist()
                        {
                            Korisnik = user,
                            Set = dbSet,
                            Komada = pieces
                        };
                        wishlistRepository.Save(wishListForSave);

                        return wishListForSave;
                    }
                    else
                    {
                        existingWishListItem.Komada += pieces;
                        wishlistRepository.Save(existingWishListItem);

                        return existingWishListItem;
                    }
                }
                else
                {
                    throw new DataException("Set not found!");
                }
            }

            throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.NotFound));


        }

        public Wishlist RemoveSetFromWishlistForUser(int userId, int setId, int pieces)
        {
            var user = korisnikRepository.GetById(userId);
            if (user != null)
            {
                var dbSet = setRepository.GetById(setId);
                if (dbSet != null)
                {
                    var existingWishlistItem = wishlistRepository.Query().FirstOrDefault(x => x.Korisnik.Id == userId && x.Set.Id == setId);

                    if (existingWishlistItem == null)
                    {
                        throw new DataException("Set ne postoji u inventaru!");
                    }
                    else
                    {
                        if (existingWishlistItem.Komada > pieces)
                        {
                            existingWishlistItem.Komada -= pieces;
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

            throw new WishlistException(WishlistException.WishlistExceptionsText(WishlistExceptionEnum.NotFound));
        }

        public IQueryable<Wishlist> Search(int userId ,string searchParameters, int take = -1, int offset = 0)
        {
            var query = wishlistRepository.Query().Where(w => w.Korisnik.Id == userId);
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

        private IQueryable<Wishlist> FilterByName(string searchPattern, IQueryable<Wishlist> query)
        {
            return query.Where(x => x.Set.Ime.Contains(searchPattern));
        }

        private IQueryable<Wishlist> FilterByDescription(string searchPattern, IQueryable<Wishlist> query)
        {
            return query.Where(x => x.Set.Opis.Contains(searchPattern));
        }

        private IQueryable<Wishlist> FilterByYear(string yearString, IQueryable<Wishlist> query)
        {
            int year;
            var parseYear = Int32.TryParse(yearString, out year);

            return parseYear ? query.Where(x => x.Set.GodinaProizvodnje == year) : query;
        }

        private IQueryable<Wishlist> FilterByTema(string tema, IQueryable<Wishlist> query)
        {
            return query.Where(x => x.Set.Tema.ImeTema == tema || (x.Set.Tema.NadTema != null && x.Set.Tema.NadTema.ImeTema == tema));
        }

        private IQueryable<Wishlist> FilterByBrojKockica(string searchPattern, IQueryable<Wishlist> query)
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

        private IQueryable<Wishlist> FilterByBrojKomada(string searchPattern, IQueryable<Wishlist> query)
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
