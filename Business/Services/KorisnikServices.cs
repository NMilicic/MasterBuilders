using Business.Interfaces;
using Data;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Exceptions;

namespace Business.Services
{
    public class KorisnikServices : IService<Korisnik>
    {
        Repository<Korisnik> korisnikRepository = new Repository<Korisnik>();
        Repository<LSet> setkRepository = new Repository<LSet>();
        Repository<Moc> mockRepository = new Repository<Moc>();

        public IQueryable<Korisnik> GetAll()
        {
            return korisnikRepository.Query();
        }

        public Korisnik GetById(int id)
        {
            return korisnikRepository.GetById(id);
        }

        public void SaveOrUpdate(Korisnik korisnik)
        {
            korisnikRepository.Save(korisnik);
        }

        public void Delete(int id)
        {
            var korisnik = korisnikRepository.GetById(id);
            if (korisnik != null)
            {
                korisnikRepository.Delete(korisnik);
            }
            else
            {
                throw new DataException("Korisnik nije pronađen!");
            }
        }

        #region Test Methods
        public List<Korisnik> KorisnikTestMethod()
        {

                var person = korisnikRepository.Query().Where(x => x.Id == 1).ToList();

            var tmp = korisnikRepository.GetById(1);
            
            return person;
        }

        public List<LSet> SetTestMethod()
        {

            var person = setkRepository.Query() ;
            return person.ToList();

        }

        public List<Moc> MocTestMethod()
        {

            var person = mockRepository.Query().ToList(); ;
            return person;


        }
        #endregion
    }
}
