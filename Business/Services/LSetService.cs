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
        IRepository<User> korisnikRepository;
        IRepository<UserLSet> inventroyRepository;
        IRepository<LSetPart> dijeloviRepository;

        public LSetService()
        {
            this.setRepository = new Repository<LSet>();
            this.wishlistRepository = new Repository<Wishlist>();
            this.korisnikRepository = new Repository<User>();
            this.inventroyRepository = new Repository<UserLSet>();
            this.dijeloviRepository = new Repository<LSetPart>();
        }

        public LSetService(
            IRepository<LSet> setRepository,
            IRepository<Wishlist> wishlistRepository,
            IRepository<User> korisnikRepository,
            IRepository<UserLSet> inventroyRepository,
            IRepository<LSetPart> dijeloviRepository
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
            var setoviDijelovi = dijeloviRepository.Query().Where(s => bricksIds.Contains(s.Part.Id));
            var sets = setoviDijelovi.Select(t => t.LSet).Distinct();

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
                var avaliableParts = user.LSets.Where(s => (s.Owned > s.Built)).SelectMany(x => x.LSet.LSetParts).ToList();
                foreach (var part in avaliableParts)
                {
                    var set = user.LSets.FirstOrDefault(s => s.LSet.Id == part.LSet.Id);
                    part.Number = (set.Owned - set.Built) * part.Number;
                }

                var possibleSets = setRepository.Query().Where(s => s.LSetParts.Count() > 0).ToList().Where(
                    s => s.LSetParts.All(
                        part => avaliableParts.Any(b => b.Color.Id == part.Color.Id) &&
                         avaliableParts.Any(b => b.Part.Id == part.Part.Id) &&
                         avaliableParts.Any(b => b.Number >= part.Number)))
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
            return query.Where(x => x.Name.Contains(searchPattern));
        }

        private IQueryable<LSet> FilterByDescription(string searchPattern, IQueryable<LSet> query)
        {
            return query.Where(x => x.Description.Contains(searchPattern));
        }

        private IQueryable<LSet> FilterByYear(string yearString, IQueryable<LSet> query)
        {
            var range = yearString.Split('-');
            if (range.Length > 1)
            {
                /*
                int lowerBound;
                var parseLowerBound = Int32.TryParse(range[0], out lowerBound);
                int upperBound;
                var parseUpperBound = Int32.TryParse(range[1], out upperBound);

                if (parseLowerBound && parseUpperBound)
                {
                    return query.Where(x => x.GodinaProizvodnje >= lowerBound && x.GodinaProizvodnje <= upperBound);
                }
                */

                int lowerBound;
                Int32.TryParse(range[0], out lowerBound);

                int upperBound;
                if (!Int32.TryParse(range[1], out upperBound))
                {
                    upperBound = Int32.MaxValue;
                }

                return query.Where(x => x.ProductionYear >= lowerBound && x.ProductionYear <= upperBound);
                
            }
            return query;
        }

        private IQueryable<LSet> FilterByTema(string tema, IQueryable<LSet> query)
        {
            //return query.Where(x => x.Tema.ImeTema == tema || (x.Tema.NadTema != null && x.Tema.NadTema.ImeTema == tema));
            return query.Where(x => x.Theme.Name == tema);
        }

        private IQueryable<LSet> FilterByNadTema(string tema, IQueryable<LSet> query)
        {
            return query.Where(x => x.Theme.BaseTheme != null && x.Theme.BaseTheme.Name == tema);
        }

        private IQueryable<LSet> FilterByBrojKockica(string searchPattern, IQueryable<LSet> query)
        {
            var range = searchPattern.Split('-');
            if (range.Length > 1)
            {
                /*
                int lowerBound;
                var parseLowerBound = Int32.TryParse(range[0], out lowerBound);
                int upperBound;
                var parseUpperBound = Int32.TryParse(range[1], out upperBound);

                if (parseLowerBound && parseUpperBound)
                {
                    return query.Where(x => x.DijeloviBroj >= lowerBound && x.DijeloviBroj <= upperBound);
                }
                */

                int lowerBound;
                Int32.TryParse(range[0], out lowerBound);

                int upperBound;
                if (!Int32.TryParse(range[1], out upperBound))
                {
                    upperBound = Int32.MaxValue;
                }

                return query.Where(x => x.NumberOfParts >= lowerBound && x.NumberOfParts <= upperBound);

            }
            return query;
        }

        #endregion
    }
}
