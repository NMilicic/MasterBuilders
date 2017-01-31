using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class LSetApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int NumberOfParts { get; set; }
        public string Description { get; set; }
        public string InstructionsUrl { get; set; }
        public string PictureUrl { get; set; }

        public ThemeApi Theme { get; set; }
        public ThemeApi BaseTheme { get; set; }
    }
}