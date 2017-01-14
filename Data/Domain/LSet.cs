using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class LSet
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual int GodinaProizvodnje { get; set; }
        public virtual int DijeloviBroj { get; set; }
        public virtual string Opis { get; set; }
        public virtual int IdTema { get; set; }

        public virtual Tema Tema { get; set; }
        public virtual IEnumerable<UserSet> KorisnikSet { get; set; }
    }
}
