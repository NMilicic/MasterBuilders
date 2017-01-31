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
        IRepository<User> korisnikRepository;

        public KorisnikServices()
        {
            this.korisnikRepository = new Repository<User>();
        }

        public KorisnikServices(IRepository<User> korisnikRepository)
        {
            this.korisnikRepository = korisnikRepository;
        }

        public IQueryable<User> GetAll(int take = -1, int offset = 0)
        {
            return korisnikRepository.Query();
        }

        public User GetById(int id)
        {
            return korisnikRepository.GetById(id);
        }

        public void SaveOrUpdate(User korisnik)
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

        public User Login(string email, string zaporka)
        {
            var user = korisnikRepository.Query().FirstOrDefault(u => u.Email == email && u.Password == zaporka);
            if (user != null)
            {
                return user;
            }
            throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.NotFound));

        }

        public User Register(User newUser)
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
