using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class UserPart
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int PartId { get; set; }

        public virtual User User { get; set; }
        public virtual Part Part { get; set; }
    }
}
