using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Color
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<MocPart> MocParts { get; set; }
        public virtual ICollection<LSetPart> LSetParts { get; set; }
    }
}
