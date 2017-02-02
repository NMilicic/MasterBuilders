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
        public virtual string Name { get; set; }
        public virtual int NumberOfParts { get; set; }
        public virtual string Theme1 { get; set; }
        public virtual string Theme2 { get; set; }
        public virtual string Theme3 { get; set; }
        public virtual string Description { get; set; }
        public virtual int ProductionYear { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<MocPart> MocParts { get; set; }

        public Moc()
        {
            MocParts = new List<MocPart>();
        }
    }
}
