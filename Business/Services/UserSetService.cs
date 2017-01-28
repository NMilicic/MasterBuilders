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
        Repository<UserSet> inventroyRepository = new Repository<UserSet>();
        Repository<LSet> setRepository = new Repository<LSet>();
        Repository<Wishlist> wishlistRepository = new Repository<Wishlist>();
        Repository<Korisnik> korisnikRepository = new Repository<Korisnik>();

        #region Default actions
        public IQueryable<UserSet> GetAll()
        {
            return inventroyRepository.Query();
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

        public IQueryable<UserSet> GetAllForUser(int userId)
        {
            return inventroyRepository.Query().Where(s => s.Korisnik.Id == userId);
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
    }
}
