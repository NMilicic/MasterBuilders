using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Business.Services;
using Data;
using Data.Domain;
using Web.Helpers;
using Web.Models;
using System.Diagnostics;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        PartService blockService = new PartService();
        LSetService lSetService = new LSetService();
        Repository<Theme> themeRepository = new Repository<Theme>();
        Repository<Category> categoryRepository = new Repository<Category>();

        [HttpGet]
        public ActionResult Sets()
        {
            IEnumerable<Theme> themes = themeRepository.Query();

            SearchSetModel model = new SearchSetModel();
            model.AllThemes = themes;
            model.Action = "Sets";
            model.Controller = "Search";
            var sets = lSetService.Search("");
            ViewBag.sets = sets.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sets(SearchSetModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Search/Sets");
            }

            IEnumerable<Theme> themes = themeRepository.Query();

            string searchParameters = SearchHelper.ConstructSearchParameters(model);

            model.AllThemes = themes;

            var sets = lSetService.Search(searchParameters);
            ViewBag.sets = sets.ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Blocks()
        {
            IEnumerable<Category> categories = categoryRepository.Query();

            SearchBlockModel model = new SearchBlockModel();
            model.AllCategories = categories;
            model.Action = "Blocks";
            model.Controller = "Search";

            var blocks = blockService.GetAll(20);
            ViewBag.blocks = blocks.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Blocks(SearchBlockModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Search/Blocks");
            }

            IEnumerable<Category> categories = categoryRepository.Query();
            model.AllCategories = categories;

            string searchParameters = SearchHelper.ConstructSearchParameters(model);
            Debug.WriteLine(searchParameters);

            var blocks = blockService.Search(searchParameters, 20);
            ViewBag.blocks = blocks.ToList();

            return View(model);
        }
    }
}