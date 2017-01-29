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
        public List<WishlistApi> GetAllSetsFromWishlistForUser(int userId, int take = -1, int offset = 0)
        {
            var tmp = wishlistService.GetAllSetsFromWishlistForUser(userId, take, offset).ProjectTo<WishlistApi>().ToList();
            return tmp;
        }

        [HttpPost]
        public HttpResponseMessage AddSetsToWishlistForUser(WishlistApi newWishlistItems)
        {
            wishlistService.AddSetToWishlistForUser(newWishlistItems.KorisnikId, newWishlistItems.SetId, newWishlistItems.Komada);

            return Request.CreateResponse(HttpStatusCode.Created, "Items added to wishlist");
        }
    }
}
