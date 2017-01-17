using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Korisnik
    {
        public  virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Zaporka { get; set; }
        public virtual string Ime { get; set;}
        public virtual string Prezime { get; set; }

        public virtual IEnumerable<Kockica> Kockice { get; set; }
        public virtual IEnumerable<UserSet> Setovi { get; set; }
        public virtual IEnumerable<Moc> Moc { get; set; }
        public virtual IEnumerable<Wishlist> Wishlist { get; set; }

        public Korisnik()
        {
            Kockice = new List<Kockica>();
            Setovi = new List<UserSet>();
            Moc = new List<Moc>();
            Wishlist = new List<Wishlist>();
        }
    }
}
