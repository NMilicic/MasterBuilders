using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Data.Domain;

namespace Web.Models
{
    public class SearchBlockModel
    {

        public IEnumerable<Category> AllCategories { get; set; }

        public string Action { get; set; }
        public string Controller { get; set; }

        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories
        {
            get
            {
                List<SelectListItem> selectCategories = AllCategories.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Name
                }).ToList();
                selectCategories.Add(new SelectListItem
                {
                    Value = "-1",
                    Text = "---",
                    Selected = true
                });

                return selectCategories;
            }
        }

        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}