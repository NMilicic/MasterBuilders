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
        public virtual int Slozeno { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Moc Moc { get; set; }
    }
}
