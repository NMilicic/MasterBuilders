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
    public class KorisnikServices : IKorisnikService
    {
        Repository<Korisnik> korisnikRepository = new Repository<Korisnik>();

        //TODO: Remov this, testing only
        Repository<LSet> setkRepository = new Repository<LSet>();
        Repository<Moc> mockRepository = new Repository<Moc>();
        Repository<UserSet> usrSetRepository = new Repository<UserSet>();

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

        public Korisnik Login(string email, string zaporka)
        {
            var user = korisnikRepository.Query().FirstOrDefault(u => u.Email == email && u.Zaporka == zaporka);
            if (user != null)
            {
                return user;
            }
            throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.NotFound));

        }

        public Korisnik Register(Korisnik newUser)
        {
            var existingUserName = korisnikRepository.Query().FirstOrDefault(u => u.Email == newUser.Email);
            if (existingUserName == null)
            {
                korisnikRepository.Save(newUser);
                return newUser;
            }
            else
            {
                throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.Taken));
            }
        }

        #region Test Methods
        public List<Korisnik> KorisnikTestMethod()
        {

            var person = korisnikRepository.Query().Where(x => x.Id == 1).ToList();

            var tmp = korisnikRepository.GetById(1);

            var bla = usrSetRepository.Query().ToList();

            return person;
        }

        public List<LSet> SetTestMethod()
        {

            var person = setkRepository.Query();
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
