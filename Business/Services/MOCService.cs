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
        IRepository<Korisnik> korisnikRepository = new Repository<Korisnik>();
        IRepository<UserMoc> userMocRepository = new Repository<UserMoc>();
        IRepository<Kockica> kockicaRepository = new Repository<Kockica>();
        IRepository<Boja> bojaRepository = new Repository<Boja>();
        IRepository<MocDijelovi> mocDijeloviRepository = new Repository<MocDijelovi>();

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
            var query = mocRepository.Query().Where(m => m.UserMoc.Korisnik.Id == authorId).Skip(offset);
            if (take > 0)
                query = query.Take(take);

            return query;
        }

        public Moc AddMoc(Moc newMoc)
        {
            var dijelovi = new List<MocDijelovi>();
            if (newMoc.Dijelovi != null && newMoc.Dijelovi.Count() > 0)
            {
                dijelovi.AddRange(newMoc.Dijelovi);
                newMoc.Dijelovi = null;
            }
            var user = korisnikRepository.GetById(newMoc.IdAutor);
            if (user != null)
            {
                var dbMoc = mocRepository.GetById(newMoc.Id);
                if (dbMoc == null)
                {
                    mocRepository.Save(newMoc);

                    var newUserMoc = new UserMoc()
                    {
                        Korisnik = user,
                        Moc = newMoc,
                        Slozeno = 0
                    };
                    userMocRepository.Save(newUserMoc);

                    if (dijelovi.Count > 0)
                    {
                        var newDijelovi = new List<MocDijelovi>();
                        foreach (var dio in dijelovi)
                        {
                            var kockica = kockicaRepository.GetById(dio.Kockica.Id);
                            if (kockica != null)
                            {
                                var boja = bojaRepository.GetById(dio.Boja.Id);
                                if (boja != null)
                                {
                                    var newMocDio = new MocDijelovi()
                                    {
                                        Boja = boja,
                                        Kockica = kockica,
                                        Broj = dio.Broj,
                                        Moc = newMoc
                                    };
                                    mocDijeloviRepository.Save(newMocDio);
                                    newDijelovi.Add(newMocDio);
                                }
                            }
                        }
                        newMoc.Dijelovi = newDijelovi;
                    }

                    return newMoc;
                }
                else
                {
                    dbMoc.Ime = newMoc.Ime;
                    dbMoc.Opis = newMoc.Opis;
                    dbMoc.Tema1 = newMoc.Tema1;
                    dbMoc.Tema2 = newMoc.Tema2;
                    dbMoc.Tema3 = newMoc.Tema3;
                    dbMoc.DijeloviBroj = newMoc.DijeloviBroj;
                    mocRepository.Save(dbMoc);

                    return dbMoc;
                }
            }

            throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.NotFound));

        }

        public Moc AddDijeloviMoc(int mocId, List<MocDijelovi> dijelovi)
        {

            var dbMoc = mocRepository.GetById(mocId);
            if (dbMoc == null)
            {
                throw new DataException("Moc not found!");
            }
            else
            {
                var newDijelovi = new List<MocDijelovi>();
                foreach (var dio in dijelovi)
                {
                    var kockica = kockicaRepository.GetById(dio.Kockica.Id);
                    if (kockica != null)
                    {
                        var boja = bojaRepository.GetById(dio.Boja.Id);
                        if (boja != null)
                        {
                            var existingMocDijelovi = mocDijeloviRepository.Query()
                                    .FirstOrDefault(m => m.Boja.Id == boja.Id && m.Kockica.Id == kockica.Id && m.Moc.Id == dbMoc.Id);
                            if (existingMocDijelovi == null)
                            {
                                var newMocDio = new MocDijelovi()
                                {
                                    Boja = boja,
                                    Kockica = kockica,
                                    Broj = dio.Broj,
                                    Moc = dbMoc
                                };
                                mocDijeloviRepository.Save(newMocDio);
                                newDijelovi.Add(newMocDio);
                            }
                            else
                            {
                                existingMocDijelovi.Broj = dio.Broj;
                                mocDijeloviRepository.Save(existingMocDijelovi);
                            }
                        }
                    }
                }
                dbMoc.Dijelovi.ToList().AddRange(newDijelovi);

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
                if (fieldSplitted.Length > 1)
                {
                    searchDictionary.Add(fieldSplitted[0], fieldSplitted[1]);
                }
            }

            return searchDictionary;
        }

        private IQueryable<Moc> FilterByName(string searchPattern, IQueryable<Moc> query)
        {
            return query.Where(x => x.Ime.Contains(searchPattern));
        }

        private IQueryable<Moc> FilterByDescription(string searchPattern, IQueryable<Moc> query)
        {
            return query.Where(x => x.Opis.Contains(searchPattern));
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
                    return query.Where(x => x.GodinaProizvodnje >= lowerBound && x.GodinaProizvodnje <= upperBound);
                }
            }
            return query;
        }

        private IQueryable<Moc> FilterByTema(string tema, IQueryable<Moc> query)
        {
            return query.Where(x => x.Tema1.Contains(tema) || x.Tema2.Contains(tema) || x.Tema3.Contains(tema));
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
                    return query.Where(x => x.DijeloviBroj >= lowerBound && x.DijeloviBroj <= upperBound);
                }
            }
            return query;
        }

        private IQueryable<Moc> FilterByAuthor(string searchPattern, IQueryable<Moc> query)
        {
            return query.Where(x =>
                x.UserMoc != null &&
                x.UserMoc.Korisnik != null &&
                (x.UserMoc.Korisnik.Ime.Contains(searchPattern) ||
                x.UserMoc.Korisnik.Prezime.Contains(searchPattern)));
        }

        #endregion
    }
}

