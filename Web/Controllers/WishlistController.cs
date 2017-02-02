using Business.Services;
using Data;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.Helpers;
using Web.Models;

namespace Web.Controllers
{
    public class WishlistController : Controller
    {
        WishlistService wishlistService = new WishlistService();
        Repository<Theme> themeRepository = new Repository<Theme>();

        [HttpGet]
        public ActionResult MySets()
        {
            IEnumerable<Theme> themes = themeRepository.Query();
            SearchSetModel model = new SearchSetModel();
            model.AllThemes = themes;
            model.Action = "MySets";
            model.Controller = "Wishlist";

            var user = HttpContext.User as CustomPrincipal;
            var sets = wishlistService.GetAllSetsFromWishlistForUser(user.Id, 20);
            ViewBag.listItems = sets;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MySets(SearchSetModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Wishlist/MySets");
            }

            IEnumerable<Theme> themes = themeRepository.Query();
            model.AllThemes = themes;

            var user = HttpContext.User as CustomPrincipal; string searchParameters = SearchHelper.ConstructSearchParameters(model);
            var sets = wishlistService.Search(user.Id, searchParameters, 20);
            ViewBag.listItems = sets;

            return View(model);
        }

        #region AJAX methods
        public JsonResult AddAjax(string setId)
        {
            var user = HttpContext.User as CustomPrincipal;
            try
            {
                wishlistService.AddSetToWishlistForUser(user.Id, int.Parse(setId), 1);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = true,
                    message = e.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult RemoveAjax(string setId)
        {
            var user = HttpContext.User as CustomPrincipal;
            try
            {
                wishlistService.RemoveSetFromWishlistForUser(user.Id, int.Parse(setId), 1);

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