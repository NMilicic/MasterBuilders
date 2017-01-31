using Web.Models;
using Data.Domain;
using Data;

namespace Web.Helpers
{
    public static class SearchHelper
    {
        public static string ConstructSearchParameters(SearchSetModel model)
        {
            Repository<Theme> themeRepository = new Repository<Theme>();

            int minPieces = 0;
            int maxPieces = int.MaxValue;
            if (model.MinPieces.HasValue) minPieces = (int)model.MinPieces;
            if (model.MaxPieces.HasValue && model.MaxPieces > minPieces) maxPieces = (int)model.MaxPieces;
            string pieces = "NumberOfParts:" + minPieces + "-" + maxPieces;
            string name = "Name:" + model.Name;

            int minYear = 0;
            int maxYear = int.MaxValue;
            if (model.MinYear.HasValue) minYear = (int)model.MinYear;
            if (model.MaxYear.HasValue && model.MaxYear > minYear) maxYear = (int)model.MaxYear;
            string years = "ProductionYear:" + minYear + "-" + maxYear;

            string theme = (model.ThemeId == "-1") ? "" : "Theme:" + themeRepository.GetById(int.Parse(model.ThemeId)).Name;

            string searchParameters = string.Join(";", new string[] { pieces, name, years, theme });

            return searchParameters;
        }

        public static string ConstructSearchParameters(SearchBlockModel model)
        {
            Repository<Category> categoryRepository = new Repository<Category>();

            string name = "Name:" + model.Name;
            string category = (model.CategoryId == "-1") ? "" : "Category:" + categoryRepository.GetById(int.Parse(model.CategoryId)).Name;

            string searchParameters = string.Join(";", new string[] { name, category });

            return searchParameters;
        }
    }
}