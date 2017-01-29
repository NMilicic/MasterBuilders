using Business.Services;
using Data;
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
        Repository<Tema> themeRepository = new Repository<Tema>();

        [HttpGet]
        public ActionResult MySets()
        {
            IEnumerable<Tema> themes = themeRepository.Query();
            SearchSetModel model = new SearchSetModel();
            model.AllThemes = themes;
            model.Action = "MySets";
            model.Controller = "Inventory";

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var sets = userSetService.GetAllForUser(Int32.Parse(user.Id));
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
            
            IEnumerable<Tema> themes = themeRepository.Query();

            //BrojKockica:0-250;Name:Prvi;GodinaProizvodnje:2017;Tema:Tema 1;
            int minPieces = 0;
            int maxPieces = int.MaxValue;
            if (model.MinPieces.HasValue) minPieces = (int)model.MinPieces;
            if (model.MaxPieces.HasValue && model.MaxPieces > minPieces) maxPieces = (int)model.MaxPieces;
            string pieces = "BrojKockica:" + minPieces + "-" + maxPieces;
            string name = "Name:" + model.Name;

            string year = (!model.Year.HasValue) ? "" : "GodinaProizvodnje:" + model.Year;
            string theme = (model.ThemeId == "-1") ? "" : "Tema:" + themeRepository.GetById(Int32.Parse(model.ThemeId)).ImeTema;

            string searchParameters = string.Join(";", new string[] { pieces, name, year, theme });

            model.AllThemes = themes;
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var sets = userSetService.Search(Int32.Parse(user.Id), searchParameters);
            ViewBag.sets = sets.ToList();

            return View(model);
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