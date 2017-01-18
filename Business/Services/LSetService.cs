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
        Repository<SetoviDijelovi> dijeloviRepository = new Repository<SetoviDijelovi>();

        #region Default actions
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

        #endregion

        #region Set specific actions

        public IQueryable<LSet> Search(string searchPattern)
        {
            var query = setRepository.Query();
            return FilterByName(searchPattern, query);
        }

        public IQueryable<LSet> GetAllSetsWithBricks(List<int> bricksIds)
        {
            var setoviDijelovi = dijeloviRepository.Query().Where(s => bricksIds.Contains(s.Kockica.Id));
            var sets = setoviDijelovi.Select(t => t.Set).Distinct();
            return sets;
        }
        
        public List<LSet> BuilderAssistent(int userId)
        {
            var user = korisnikRepository.GetById(userId);
            var avaliableParts = user.Setovi.Where(s => (s.Komada > s.Slozeno)).SelectMany(x => x.Set.Dijelovi).ToList();
            foreach(var part in avaliableParts)
            {
                var set = user.Setovi.FirstOrDefault(s => s.Set.Id == part.Set.Id);
                part.Broj = (set.Komada - set.Slozeno) * part.Broj;
            }

            var possibleSets = setRepository.Query().Where(s => s.Dijelovi.Count() > 0).ToList().Where(
                s => s.Dijelovi.All(
                    part => avaliableParts.Any(b => b.Boja.Id == part.Boja.Id) &&
                     avaliableParts.Any(b => b.Kockica.Id == part.Kockica.Id) &&
                     avaliableParts.Any(b => b.Broj >= part.Broj)))
                     .ToList();

           return possibleSets;
            
        }
        #endregion

        #region Private methods

        private IQueryable<LSet> FilterByName(string searchPattern, IQueryable<LSet> query)
        {
            return query.Where(x => x.Ime.Contains(searchPattern));
        }

        private IQueryable<LSet> FilterByDescription(string searchPattern, IQueryable<LSet> query)
        {
            return query.Where(x => x.Opis.Contains(searchPattern));
        }

        #endregion
    }
}
