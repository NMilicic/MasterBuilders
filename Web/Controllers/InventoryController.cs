using Business.Services;
using Data;
using Data.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Helpers;

namespace Web.Controllers
{
    public class InventoryController : Controller
    {
        UserSetService userSetService = new UserSetService();
        LSetService setService = new LSetService();
        Repository<Theme> themeRepository = new Repository<Theme>();

        [HttpGet]
        public ActionResult MySets()
        {
            IEnumerable<Theme> themes = themeRepository.Query();
            SearchSetModel model = new SearchSetModel();
            model.AllThemes = themes;
            model.Action = "MySets";
            model.Controller = "Inventory";

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var sets = userSetService.GetAllForUser(int.Parse(user.Id));
            ViewBag.sets = sets;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MySets(SearchSetModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Inventory/MySets");
            }
            
            IEnumerable<Theme> themes = themeRepository.Query();

            
            model.AllThemes = themes;
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            
            string searchParameters = SearchHelper.ConstructSearchParameters(model);
            var sets = userSetService.Search(int.Parse(user.Id), searchParameters);
            ViewBag.sets = sets.ToList();

            return View(model);
        }

        public ActionResult BuilderAssistant()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var sets = setService.BuilderAssistent(int.Parse(user.Id));
            ViewBag.sets = sets;

            return View();
        }

        public JsonResult AddAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()); 
            userSetService.AddToInventory(int.Parse(user.Id), int.Parse(setId), 1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            userSetService.RemoveFromInventory(int.Parse(user.Id), int.Parse(setId), 1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuiltAddAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            userSetService.MarkSetAsCompleted(int.Parse(user.Id), int.Parse(setId), 1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuiltRemoveAjax(string setId)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            userSetService.MarkSetAsCompleted(int.Parse(user.Id), int.Parse(setId), -1);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}