using Business.Interfaces;
using Data;
using Data.Domain;
using System.Linq;

namespace Business.Services
{
    public class KockiceService : IKockiceService
    {
        Repository<Kockica> kockicaRepository = new Repository<Kockica>();

        public IQueryable<Kockica> GetAll(int take = -1, int offset = 0)
        {
            var query = kockicaRepository.Query().Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }

        public Kockica GetById(int id)
        {
            return kockicaRepository.GetById(id);
        }

        public IQueryable<Kockica> GetAllForUser(int userId, int take = -1, int offset = 0)
        {
            var query = kockicaRepository.Query().Where(x => x.Korisnik.Any(u => u.Id == userId)).Skip(offset);
            if (take > 0)
                query = query.Take(take);
            return query;
        }
    }
}
