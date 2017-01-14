using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class KorisnikApi
    {
        public  virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Zaporka { get; set; }
        public virtual string Ime { get; set;}
        public virtual string Prezime { get; set; }
    }
}
