using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Moc
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual int DijeloviBroj { get; set; }
        public virtual string Tema1 { get; set; }
        public virtual string Tema2 { get; set; }
        public virtual string Tema3 { get; set; }
        public virtual string Opis { get; set; }
        public virtual int IdAutor { get; set; }
        public virtual int GodinaProizvodnje { get; set; }

        public virtual Korisnik Autor { get; set; }
        public virtual IEnumerable<MocDijelovi> Dijelovi { get; set; }
    }
}
