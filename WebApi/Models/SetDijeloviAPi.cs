using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class SetDijeloviApi
    {
        public int Id { get; set; }
        public int Broj { get; set; }

        public BojaApi Boja { get; set; }
        public KockicaApi Kockica { get; set; }
    }
}