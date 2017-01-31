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
    public class MOCService : IMOCService
    {
        IRepository<Moc> mocRepository = new Repository<Moc>();
        IRepository<User> korisnikRepository = new Repository<User>();
        IRepository<UserMoc> userMocRepository = new Repository<UserMoc>();
        IRepository<Part> kockicaRepository = new Repository<Part>();
        IRepository<Color> bojaRepository = new Repository<Color>();
        IRepository<MocPart> mocDijeloviRepository = new Repository<MocPart>();

        #region Default actions
        public IQueryable<Moc> GetAll(int take = -1, int offset = 0)
        {
            var query = mocRepository.Query().Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public Moc GetById(int id)
        {
            return mocRepository.GetById(id);
        }

        public void SaveOrUpdate(Moc moc)
        {
            mocRepository.Save(moc);
        }

        public void Delete(int id)
        {
            var set = mocRepository.GetById(id);
            if (set != null)
            {
                mocRepository.Delete(set);
            }
            else
            {
                throw new DataException("Moc nije pronađen!");
            }
        }

        #endregion

        public IQueryable<Moc> GetAllByAuthor(int authorId, int take = -1, int offset = 0)
        {
            var query = mocRepository.Query().Where(m => m.UserMoc.User.Id == authorId).Skip(offset);
            if (take > 0)
                query = query.Take(take);

            return query;
        }

        public Moc AddMoc(Moc newMoc)
        {
            var dijelovi = new List<MocPart>();
            if (newMoc.MocParts != null && newMoc.MocParts.Count() > 0)
            {
                dijelovi.AddRange(newMoc.MocParts);
                newMoc.MocParts = null;
            }
            var user = korisnikRepository.GetById(newMoc.AuthorId);
            if (user != null)
            {
                var dbMoc = mocRepository.GetById(newMoc.Id);
                if (dbMoc == null)
                {
                    mocRepository.Save(newMoc);

                    var newUserMoc = new UserMoc()
                    {
                        User = user,
                        Moc = newMoc,
                        Built = 0
                    };
                    userMocRepository.Save(newUserMoc);

                    if (dijelovi.Count > 0)
                    {
                        var newDijelovi = new List<MocPart>();
                        foreach (var dio in dijelovi)
                        {
                            var kockica = kockicaRepository.GetById(dio.Part.Id);
                            if (kockica != null)
                            {
                                var boja = bojaRepository.GetById(dio.Color.Id);
                                if (boja != null)
                                {
                                    var newMocDio = new MocPart()
                                    {
                                        Color = boja,
                                        Part = kockica,
                                        Number = dio.Number,
                                        Moc = newMoc
                                    };
                                    mocDijeloviRepository.Save(newMocDio);
                                    newDijelovi.Add(newMocDio);
                                }
                            }
                        }
                        newMoc.MocParts = newDijelovi;
                    }

                    return newMoc;
                }
                else
                {
                    dbMoc.Name = newMoc.Name;
                    dbMoc.Description = newMoc.Description;
                    dbMoc.Theme1 = newMoc.Theme1;
                    dbMoc.Theme2 = newMoc.Theme2;
                    dbMoc.Theme3 = newMoc.Theme3;
                    dbMoc.NumberOfParts = newMoc.NumberOfParts;
                    mocRepository.Save(dbMoc);

                    return dbMoc;
                }
            }

            throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.NotFound));

        }

        public Moc AddDijeloviMoc(int mocId, List<MocPart> dijelovi)
        {

            var dbMoc = mocRepository.GetById(mocId);
            if (dbMoc == null)
            {
                throw new DataException("Moc not found!");
            }
            else
            {
                var newDijelovi = new List<MocPart>();
                foreach (var dio in dijelovi)
                {
                    var kockica = kockicaRepository.GetById(dio.Part.Id);
                    if (kockica != null)
                    {
                        var boja = bojaRepository.GetById(dio.Color.Id);
                        if (boja != null)
                        {
                            var existingMocDijelovi = mocDijeloviRepository.Query()
                                    .FirstOrDefault(m => m.Color.Id == boja.Id && m.Part.Id == kockica.Id && m.Moc.Id == dbMoc.Id);
                            if (existingMocDijelovi == null)
                            {
                                var newMocDio = new MocPart()
                                {
                                    Color = boja,
                                    Part = kockica,
                                    Number = dio.Number,
                                    Moc = dbMoc
                                };
                                mocDijeloviRepository.Save(newMocDio);
                                newDijelovi.Add(newMocDio);
                            }
                            else
                            {
                                existingMocDijelovi.Number = dio.Number;
                                mocDijeloviRepository.Save(existingMocDijelovi);
                            }
                        }
                    }
                }
                dbMoc.MocParts.ToList().AddRange(newDijelovi);

                return dbMoc;
            }

        }

        public IQueryable<Moc> Search(string searchParameters, int take = -1, int offset = 0)
        {
            var query = mocRepository.Query();
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
                    case SearchEnum.Author:
                        query = FilterByAuthor(field.Value, query);
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

        private IQueryable<Moc> FilterByName(string searchPattern, IQueryable<Moc> query)
        {
            return query.Where(x => x.Name.Contains(searchPattern));
        }

        private IQueryable<Moc> FilterByDescription(string searchPattern, IQueryable<Moc> query)
        {
            return query.Where(x => x.Description.Contains(searchPattern));
        }

        private IQueryable<Moc> FilterByYear(string yearString, IQueryable<Moc> query)
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
                    return query.Where(x => x.ProductionYear >= lowerBound && x.ProductionYear <= upperBound);
                }
            }
            return query;
        }

        private IQueryable<Moc> FilterByTema(string tema, IQueryable<Moc> query)
        {
            return query.Where(x => x.Theme1.Contains(tema) || x.Theme2.Contains(tema) || x.Theme3.Contains(tema));
        }

        private IQueryable<Moc> FilterByBrojKockica(string searchPattern, IQueryable<Moc> query)
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
                    return query.Where(x => x.NumberOfParts >= lowerBound && x.NumberOfParts <= upperBound);
                }
            }
            return query;
        }

        private IQueryable<Moc> FilterByAuthor(string searchPattern, IQueryable<Moc> query)
        {
            return query.Where(x =>
                x.UserMoc != null &&
                x.UserMoc.User != null &&
                (x.UserMoc.User.FirstName.Contains(searchPattern) ||
                x.UserMoc.User.LastName.Contains(searchPattern)));
        }

        #endregion
    }
}

