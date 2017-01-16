using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class TemaApi
    {
        public int IdTema { get; set; }
        public string ImeTema { get; set; }

        public TemaApi NadTema { get; set; }
    }
}