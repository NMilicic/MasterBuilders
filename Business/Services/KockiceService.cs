using Business.Interfaces;
using Data;
using Data.Domain;
using System.Linq;

namespace Business.Services
{
    public class KockiceService : IKockiceService
    {
        Repository<Kockica> kockicaRepository = new Repository<Kockica>();

        public IQueryable<Kockica> GetAll()
        {
            return kockicaRepository.Query();
        }

        public IQueryable<Kockica> GetAllForUser(int userId)
        {
            return kockicaRepository.Query().Where(x => x.Korisnik.Any(u => u.Id == userId));
        }
    }
}
