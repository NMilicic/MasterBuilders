﻿using Data.Domain;
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
            WishlistService wishlistService = new WishlistService();
            var userId = Int32.Parse(User.Identity.GetUserId());

            wishlistService.AddSetToWishlistForUser(userId, Int32.Parse(setId), 1);
            
            return Json("success");
        }
    }
}