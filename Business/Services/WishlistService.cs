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
        Repository<Wishlist> wishlistRepository = new Repository<Wishlist>();
        Repository<Korisnik> korisnikRepository = new Repository<Korisnik>();
        Repository<LSet> setRepository = new Repository<LSet>();

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
    }
}
