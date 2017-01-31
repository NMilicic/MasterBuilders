using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class LSetPart
    {
        public virtual int Id { get; set; }
        public virtual int Number { get; set; }

        public virtual Color Color { get; set; }
        public virtual Part Part { get; set; }
        public virtual LSet LSet { get; set; }
    }
}
