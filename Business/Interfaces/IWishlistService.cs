using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IWishlistService: IService<Wishlist>
    {
        IQueryable<Wishlist> GetAllSetsFromWishlistForUser(int userId, int take = -1, int offset = 0);
        Wishlist AddSetToWishlistForUser(int userId, int setId, int pieces);
        Wishlist RemoveSetFromWishlistForUser(int userId, int setId, int pieces);
    }
}
