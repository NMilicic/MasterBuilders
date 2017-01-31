using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MocApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfParts { get; set; }
        public string Theme1 { get; set; }
        public string Theme2 { get; set; }
        public string Theme3 { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int ProductionYear { get; set; }
        public List<MocPartApi> MocParts { get; set; }
    }
}