using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class SetApi
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public int GodinaProizvodnje { get; set; }
        public int DijeloviBroj { get; set; }
        public string Opis { get; set; }

        public TemaApi Tema { get; set; }
        public TemaApi NadTema { get; set; }
    }
}