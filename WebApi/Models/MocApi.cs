using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MocApi
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public int DijeloviBroj { get; set; }
        public string Tema1 { get; set; }
        public string Tema2 { get; set; }
        public string Tema3 { get; set; }
        public string Opis { get; set; }
        public int IdAutor { get; set; }
        public int GodinaProizvodnje { get; set; }
        public List<MocDijeloviApi> Dijelovi { get; set; }
    }
}