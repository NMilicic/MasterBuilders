using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helpers
{
    public static class SearchHelper
    {
        public static string ConstructSearchParameters(Web.Models.SearchSetModel model)
        {
            Data.Repository<Data.Domain.Theme> themeRepository = new Data.Repository<Data.Domain.Theme>();
            //BrojKockica:0-250;Name:Prvi;GodinaProizvodnje:2016-2017;Tema:Tema 1;
            int minPieces = 0;
            int maxPieces = int.MaxValue;
            if (model.MinPieces.HasValue) minPieces = (int)model.MinPieces;
            if (model.MaxPieces.HasValue && model.MaxPieces > minPieces) maxPieces = (int)model.MaxPieces;
            string pieces = "BrojKockica:" + minPieces + "-" + maxPieces;
            string name = "Name:" + model.Name;

            int minYear = 0;
            int maxYear = int.MaxValue;
            if (model.MinYear.HasValue) minYear = (int)model.MinYear;
            if (model.MaxYear.HasValue && model.MaxYear > minYear) maxYear = (int)model.MaxYear;
            string years = "Year:" + minYear + "-" + maxYear;

            string theme = (model.ThemeId == "-1") ? "" : "Tema:" + themeRepository.GetById(System.Int32.Parse(model.ThemeId)).Name;

            string searchParameters = string.Join(";", new string[] { pieces, name, years, theme });

            return searchParameters;
        }
    }
}