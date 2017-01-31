using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ThemeApi
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ThemeApi BaseTheme { get; set; }
    }
}