using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Tema
    {
        public virtual int IdTema { get; set; }
        public virtual int IdNadTema { get; set; }
        public virtual string ImeTema { get; set; }

        public virtual Tema NadTema { get; set; }
    }
}
