using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Data;

namespace Web.Models
{
    public class SearchSetModel
    {
        public IEnumerable<Data.Domain.Tema> AllThemes { get; set; }

        [Display(Name = "Theme")]
        public string ThemeName { get; set; }

        public IEnumerable<SelectListItem> Themes
        {
            get
            {
                var selectThemes = AllThemes.Select(f => new SelectListItem
                {
                    Value = f.ImeTema,
                    Text = f.ImeTema
                });
                return selectThemes;
            }
        }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Year")]
        [Range(0, int.MaxValue, ErrorMessage = "Must be positive number")]
        public int? Year { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive number")]
        public int? MinPieces { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive number")]
        public int? MaxPieces { get; set; }
    }
}