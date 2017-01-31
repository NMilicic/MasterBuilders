using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class LSetPartApi
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public ColorApi Color { get; set; }
        public PartApi Part { get; set; }
    }
}