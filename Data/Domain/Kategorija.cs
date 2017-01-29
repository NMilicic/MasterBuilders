using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Kategorija
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }

        public virtual IEnumerable<Kockica> Kockice { get; set; }
    }
}
