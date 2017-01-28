using Data.Domain;
using Business.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class WishlistController : Controller
    {
        // GET: Wishlist
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            KorisnikServices userService = new KorisnikServices();
            LSetService setService = new LSetService();
            WishlistService wishlistService = new WishlistService();

            Wishlist wishlist = new Wishlist();
            wishlist.Korisnik = userService.GetById(1);
            wishlist.Set = setService.GetById(Int32.Parse(setId));
            wishlist.Komada = 1;

            wishlistService.SaveOrUpdate(wishlist);
            
            return Json("succes");
        }
    }
}