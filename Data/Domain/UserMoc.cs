using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class UserMoc
    {
        public virtual int Id { get; set; }
        public virtual int Built { get; set; }

        public virtual User User { get; set; }
        public virtual Moc Moc { get; set; }
    }
}
