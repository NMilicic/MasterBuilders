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
using System;
using Business.Exceptions;

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

            var user = HttpContext.User as CustomPrincipal;
            var sets = userSetService.GetAllForUser(user.Id);
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
            var user = HttpContext.User as CustomPrincipal;

            string searchParameters = SearchHelper.ConstructSearchParameters(model);
            var sets = userSetService.Search(user.Id, searchParameters);
            ViewBag.sets = sets.ToList();

            return View(model);
        }

        public ActionResult BuilderAssistant()
        {
            var user = HttpContext.User as CustomPrincipal;

            var sets = setService.BuilderAssistent(user.Id);
            ViewBag.sets = sets;

            return View();
        }

        #region AJAX methods
        public JsonResult AddAjax(string setId)
        {
            var user = HttpContext.User as CustomPrincipal;
            try
            {
                userSetService.AddToInventory(user.Id, int.Parse(setId), 1);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { error = true, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RemoveAjax(string setId)
        {
            var user = HttpContext.User as CustomPrincipal;
            try
            {
                userSetService.RemoveFromInventory(user.Id, int.Parse(setId), 1);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { error = true, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BuiltAddAjax(string setId)
        {
            var user = HttpContext.User as CustomPrincipal;
            try
            {
                userSetService.MarkSetAsCompleted(user.Id, int.Parse(setId), 1);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { error = true, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BuiltRemoveAjax(string setId)
        {
            var user = HttpContext.User as CustomPrincipal;
            try
            {
                userSetService.MarkSetAsCompleted(user.Id, int.Parse(setId), -1);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { error = true, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}