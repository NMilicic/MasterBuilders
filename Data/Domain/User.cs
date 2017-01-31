using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class User
    {
        public  virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string FirstName { get; set;}
        public virtual string LastName { get; set; }

        public virtual IEnumerable<Part> Parts { get; set; }
        public virtual IEnumerable<UserLSet> LSets { get; set; }
        public virtual IEnumerable<Moc> Mocs { get; set; }
        public virtual IEnumerable<Wishlist> Wishlists { get; set; }

        public User()
        {
            Parts = new List<Part>();
            LSets = new List<UserLSet>();
            Mocs = new List<Moc>();
            Wishlists = new List<Wishlist>();
        }
    }
}
