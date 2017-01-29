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
        IRepository<Korisnik> korisnikRepository;

        public KorisnikServices()
        {
            this.korisnikRepository = new Repository<Korisnik>();
        }

        public KorisnikServices(IRepository<Korisnik> korisnikRepository)
        {
            this.korisnikRepository = korisnikRepository;
        }

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
    }
}
