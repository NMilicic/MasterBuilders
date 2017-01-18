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
