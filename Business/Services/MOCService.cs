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
        Repository<Moc> mocRepository = new Repository<Moc>();
        Repository<Korisnik> korisnikRepository = new Repository<Korisnik>();
        Repository<UserMoc> userMocRepository = new Repository<UserMoc>();
        Repository<Kockica> kockicaRepository = new Repository<Kockica>();
        Repository<Boja> bojaRepository = new Repository<Boja>();
        Repository<MocDijelovi> mocDijeloviRepository = new Repository<MocDijelovi>();

        public IQueryable<Moc> GetAllByAuthor(int authorId)
        {
            var mocs = mocRepository.Query().Where(m => m.UserMoc.Korisnik.Id == authorId);
            return mocs;
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
    }
}

