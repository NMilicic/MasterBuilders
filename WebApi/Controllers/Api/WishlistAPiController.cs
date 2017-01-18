using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers.Api
{
    public class WishlistAPiController : ApiController
    {
        public WishlistService wishlistService = new WishlistService();
        public List<WishlistApi> GetAllSetsFromWishlistForUser(int userId)
        {
            var tmp = wishlistService.GetAllSetsFromWishlistForUser(userId).ProjectTo<WishlistApi>().ToList();
            return tmp;
        }

        [HttpPost]
        public HttpResponseMessage AddSetsToWishlistForUser(List<WishlistApi> newWishlistItems)
        {
            foreach (var list in newWishlistItems)
            {
                wishlistService.AddSetToWishlistForUser(list.KorisnikId, list.Set.Id, list.Komada);
            }

            return Request.CreateResponse(HttpStatusCode.Created, "Items added to wishlist");
        }
    }
}
