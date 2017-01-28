using Business.Services;
using Data.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class InventoryController : Controller
    {
        UserSetService userSetService = new UserSetService();
        public ActionResult MySets()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var sets = userSetService.GetAllForUser(Int32.Parse(user.Id));
            ViewBag.sets = sets;
            return View();
        }

        public JsonResult AddAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            UserSetService usetSetService = new UserSetService();
            UserSet userSet = userSetService.GetById(Int32.Parse(setId));

            userSetService.AddToInventory(Int32.Parse(user.Id), userSet.Set.Id, 1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            UserSetService usetSetService = new UserSetService();
            UserSet userSet = userSetService.GetById(Int32.Parse(setId));

            userSetService.RemoveFromInventory(Int32.Parse(user.Id), userSet.Set.Id, 1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuiltAddAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            UserSetService usetSetService = new UserSetService();

            UserSet set = userSetService.GetById(Int32.Parse(setId));
            if (Int32.Parse(user.Id) == set.Korisnik.Id && set.Slozeno < set.Komada)
            {
                set.Slozeno += 1;
                userSetService.SaveOrUpdate(set);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuiltRemoveAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            UserSetService usetSetService = new UserSetService();

            UserSet set = userSetService.GetById(Int32.Parse(setId));
            if (set.Slozeno > 0 && Int32.Parse(user.Id) == set.Korisnik.Id)
            {
                set.Slozeno -= 1;
                userSetService.SaveOrUpdate(set);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}