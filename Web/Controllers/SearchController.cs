using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Services;
using Data;
using System.Diagnostics;

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

            //brojkockica:0-250;Name:Prvi;GodinaProizvodnje:2017;Tema:Tema 1;
            if (!model.MinPieces.HasValue) model.MinPieces = 0;
            if (!model.MaxPieces.HasValue || model.MaxPieces < model.MinPieces) model.MaxPieces = int.MaxValue;
            string pieces = "brojkockica:" + model.MinPieces + "-" + model.MaxPieces;
            Debug.WriteLine(pieces);
            string name = "Name:" + model.Name;

            string year = (!model.Year.HasValue) ? "" : "GodinaProizvodnje:" + model.Year;
            string theme = (model.ThemeName == "") ? "" : "Tema:" + model.ThemeName;

            string searchParameters = string.Join(";", new string[] { pieces, name, year, theme });

            Repository<Data.Domain.Tema> themeRepository = new Repository<Data.Domain.Tema>();
            IEnumerable<Data.Domain.Tema> themes = themeRepository.Query();

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