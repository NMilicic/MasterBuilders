using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Business.Services;
using Data;
using System.Diagnostics;
using Web.Helpers;

namespace Web.Controllers
{
    public class SearchController : Controller
    {

        [HttpGet]
        public ActionResult Sets()
        {
            Repository<Data.Domain.Tema> themeRepository = new Repository<Data.Domain.Tema>();
            IEnumerable<Data.Domain.Tema> themes = themeRepository.Query();

            Models.SearchSetModel model = new Models.SearchSetModel();
            model.AllThemes = themes;
            model.Action = "Sets";
            model.Controller = "Search";
            LSetService lSetService = new LSetService();
            var sets = lSetService.Search("");
            ViewBag.sets = sets.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sets(Models.SearchSetModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Search/Sets");
            }

            LSetService lSetService = new LSetService();
            Repository<Data.Domain.Tema> themeRepository = new Repository<Data.Domain.Tema>();
            IEnumerable<Data.Domain.Tema> themes = themeRepository.Query();

            string searchParameters = SearchHelper.ConstructSearchParameters(model);
            Debug.WriteLine(searchParameters);

            model.AllThemes = themes;

            var sets = lSetService.Search(searchParameters);
            ViewBag.sets = sets.ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Blocks()
        {
            KockiceService blockService = new KockiceService();
            var blocks = blockService.GetAll();
            ViewBag.blocks = blocks.ToList();

            return View();
        }
    }
}