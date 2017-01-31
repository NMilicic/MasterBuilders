using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Part
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Category Category { get; set; }
        public virtual string PictureUrl { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<LSetPart> LSetParts { get; set; }
    }
}
