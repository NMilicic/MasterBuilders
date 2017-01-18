using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Kockica
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Kategorija { get; set; }

        public virtual IEnumerable<Korisnik> Korisnik { get; set; }
        public virtual IEnumerable<SetoviDijelovi> SetoviDijelovi { get; set; }
    }
}
