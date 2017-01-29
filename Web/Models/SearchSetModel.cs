using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Data;

namespace Web.Models
{
    public class SearchSetModel
    {
        public IEnumerable<Data.Domain.Tema> AllThemes { get; set; }

        [Display(Name = "Theme")]
        public string ThemeId { get; set; }

        public IEnumerable<SelectListItem> Themes
        {
            get
            {
                List<SelectListItem> selectThemes = AllThemes.Select(f => new SelectListItem
                {
                    Value = f.IdTema.ToString(),
                    Text = f.ImeTema
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

        [Display(Name = "Year")]
        [Range(0, int.MaxValue, ErrorMessage = "Must be positive number")]
        public int? Year { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive number")]
        public int? MinPieces { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Must be positive number")]
        public int? MaxPieces { get; set; }
    }
}