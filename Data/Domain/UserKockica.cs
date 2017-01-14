using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class UserKockica
    {
        public virtual int Id { get; set; }
        public virtual int IdUser { get; set; }
        public virtual int IdKockica { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Kockica Kockica { get; set; }
    }
}
