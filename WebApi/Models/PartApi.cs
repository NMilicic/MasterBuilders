using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class PartApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryApi Category { get; set; }
    }
}