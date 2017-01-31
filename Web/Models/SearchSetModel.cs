using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Models
{
    public class SearchSetModel
    {
        public IEnumerable<Data.Domain.Theme> AllThemes { get; set; }

        public string Action { get; set; }
        public string Controller { get; set; }

        [Display(Name = "Theme")]
        public string ThemeId { get; set; }

        public IEnumerable<SelectListItem> Themes
        {
            get
            {
                List<SelectListItem> selectThemes = AllThemes.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Name
                }).ToList();
                selectThemes.Add(new SelectListItem
                {
                    Value = "-1",
                    Text = "---",
                    Selected = true
                });
                
                return selectThemes;
            }
        }

        [Display(Name = "Name")]
        public string Name { get; set; }

        
        [Range(0, int.MaxValue, ErrorMessage = "Must be positive number")]
        public int? MinYear { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive number")]
        public int? MaxYear { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Must be positive number")]
        public int? MinPieces { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive number")]
        public int? MaxPieces { get; set; }
    }
}