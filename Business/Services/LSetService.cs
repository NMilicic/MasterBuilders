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
        IRepository<LSet> setRepository;
        IRepository<Wishlist> wishlistRepository;
        IRepository<Korisnik> korisnikRepository;
        IRepository<UserSet> inventroyRepository;
        IRepository<SetoviDijelovi> dijeloviRepository;

        public LSetService()
        {
            this.setRepository = new Repository<LSet>();
            this.wishlistRepository = new Repository<Wishlist>();
            this.korisnikRepository = new Repository<Korisnik>();
            this.inventroyRepository = new Repository<UserSet>();
            this.dijeloviRepository = new Repository<SetoviDijelovi>();
        }

        public LSetService(
            IRepository<LSet> setRepository,
            IRepository<Wishlist> wishlistRepository,
            IRepository<Korisnik> korisnikRepository,
            IRepository<UserSet> inventroyRepository,
            IRepository<SetoviDijelovi> dijeloviRepository
            )
        {
            this.setRepository = setRepository;
            this.wishlistRepository = wishlistRepository;
            this.korisnikRepository = korisnikRepository;
            this.inventroyRepository = inventroyRepository;
            this.dijeloviRepository = dijeloviRepository;
        }

        #region Default actions
        public IQueryable<LSet> GetAll(int take = -1, int offset = 0)
        {
            var query = setRepository.Query().Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
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

        public IQueryable<LSet> Search(string searchParameters, int take = -1, int offset = 0)
        {
            var query = setRepository.Query();
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
                    case SearchEnum.NadTema:
                        query = FilterByNadTema(field.Value, query);
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
            var setoviDijelovi = dijeloviRepository.Query().Where(s => bricksIds.Contains(s.Kockica.Id));
            var sets = setoviDijelovi.Select(t => t.Set).Distinct();

            sets = sets.Skip(offset);
            if (take > 0)
                sets = sets.Take(take);

            return sets;
        }

        public List<LSet> BuilderAssistent(int userId)
        {
            var user = korisnikRepository.GetById(userId);
            if (user != null)
            {
                var avaliableParts = user.Setovi.Where(s => (s.Komada > s.Slozeno)).SelectMany(x => x.Set.Dijelovi).ToList();
                foreach (var part in avaliableParts)
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
            else
            {
                throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.NotFound));
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
            return query.Where(x => x.Ime.Contains(searchPattern));
        }

        private IQueryable<LSet> FilterByDescription(string searchPattern, IQueryable<LSet> query)
        {
            return query.Where(x => x.Opis.Contains(searchPattern));
        }

        private IQueryable<LSet> FilterByYear(string yearString, IQueryable<LSet> query)
        {
            var range = yearString.Split('-');
            if (range.Length > 1)
            {
                int lowerBound;
                var parseLowerBound = Int32.TryParse(range[0], out lowerBound);
                int upperBound;
                var parseUpperBound = Int32.TryParse(range[1], out upperBound);

                if (parseLowerBound && parseUpperBound)
                {
                    return query.Where(x => x.GodinaProizvodnje >= lowerBound && x.GodinaProizvodnje <= upperBound);
                }
            }
            return query;
        }

        private IQueryable<LSet> FilterByTema(string tema, IQueryable<LSet> query)
        {
            return query.Where(x => x.Tema.ImeTema == tema || (x.Tema.NadTema != null && x.Tema.NadTema.ImeTema == tema));
        }

        private IQueryable<LSet> FilterByNadTema(string tema, IQueryable<LSet> query)
        {
            return query.Where(x => x.Tema.NadTema != null && x.Tema.NadTema.ImeTema == tema);
        }

        private IQueryable<LSet> FilterByBrojKockica(string searchPattern, IQueryable<LSet> query)
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
                    return query.Where(x => x.DijeloviBroj >= lowerBound && x.DijeloviBroj <= upperBound);
                }
            }
            return query;
        }

        #endregion
    }
}
