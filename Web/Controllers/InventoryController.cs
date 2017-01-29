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
            userSetService.AddToInventory(Int32.Parse(user.Id), Int32.Parse(setId), 1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            userSetService.RemoveFromInventory(Int32.Parse(user.Id), Int32.Parse(setId), 1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuiltAddAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            

            userSetService.MarkSetAsCompleted(Int32.Parse(user.Id), Int32.Parse(setId), 1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuiltRemoveAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            userSetService.MarkSetAsCompleted(Int32.Parse(user.Id), Int32.Parse(setId), -1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}