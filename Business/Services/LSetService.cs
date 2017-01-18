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
        Repository<LSet> setRepository = new Repository<LSet>();
        Repository<Wishlist> wishlistRepository = new Repository<Wishlist>();
        Repository<Korisnik> korisnikRepository = new Repository<Korisnik>();
        Repository<UserSet> inventroyRepository = new Repository<UserSet>();

        public IQueryable<LSet> GetAll()
        {
            return setRepository.Query();
        }

        public LSet GetById(int id)
        {
            return setRepository.GetById(id);
        }

        public void SaveOrUpdate(LSet set)
        {
            setRepository.Save(set);
        }

        public void Delete(int id)
        {
            var set = setRepository.GetById(id);
            if (set != null)
            {
                setRepository.Delete(set);
            }
            else
            {
                throw new DataException("Set nije pronađen!");
            }
        }

        public IQueryable<LSet> Search(string searchPattern)
        {
            var query = setRepository.Query();
            return FilterByName(searchPattern, query);
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

                    if(existingWishListItem != null)
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

        private IQueryable<LSet> FilterByName(string searchPattern, IQueryable<LSet> query)
        {
            return query.Where(x => x.Ime.Contains(searchPattern));
        }

        private IQueryable<LSet> FilterByDescription(string searchPattern, IQueryable<LSet> query)
        {
            return query.Where(x => x.Opis.Contains(searchPattern));
        }
    }
}
