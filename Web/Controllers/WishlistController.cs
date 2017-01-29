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
        WishlistService wishlistService = new WishlistService();

        public ActionResult MySets()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var sets = wishlistService.GetAllSetsFromWishlistForUser(Int32.Parse(user.Id));
            ViewBag.sets = sets;

            return View();
        }

        public JsonResult AddAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            WishlistService wishlistService = new WishlistService();
            wishlistService.AddSetToWishlistForUser(Int32.Parse(user.Id), Int32.Parse(setId), 1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            WishlistService wishlistService = new WishlistService();
            wishlistService.RemoveSetFromWishlistForUser(Int32.Parse(user.Id), Int32.Parse(setId), 1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}