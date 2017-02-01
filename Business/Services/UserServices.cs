using Business.Interfaces;
using Data;
using Data.Domain;
using System.Linq;
using Business.Exceptions;

namespace Business.Services
{
    public class UserServices : IKorisnikService
    {
        IRepository<User> userRepository;

        public UserServices()
        {
            this.userRepository = new Repository<User>();
        }

        public UserServices(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IQueryable<User> GetAll(int take = -1, int offset = 0)
        {
            return userRepository.Query();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public void SaveOrUpdate(User korisnik)
        {
            userRepository.Save(korisnik);
        }

        public void Delete(int id)
        {
            var user = userRepository.GetById(id);
            if (user != null)
            {
                userRepository.Delete(user);
            }
            else
            {
                throw new DataException("User not found!");
            }
        }

        public User Login(string email, string password)
        {
            var user = userRepository.Query().FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                return user;
            }
            throw new UserException(UserException.UserExceptionsText(UserExceptionEnum.NotFound));

        }

        public User Register(User newUser)
        {
            var existingUserName = userRepository.Query().FirstOrDefault(u => u.Email == newUser.Email);
            if (existingUserName == null)
            {
                userRepository.Save(newUser);
                return newUser;
            }
            else
            {
                throw new UserException(UserException.UserExceptionsText(UserExceptionEnum.Taken));
            }
        }
    }
}
