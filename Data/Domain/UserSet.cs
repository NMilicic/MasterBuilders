using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class UserSet
    {
        public virtual int Id { get; set; }
        public virtual int IdUser { get; set; }
        public virtual int IdSet { get; set; }
        public virtual int Slozeno { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual LSet Set { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as UserSet;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.IdUser == other.IdUser &&
                this.IdSet == other.IdSet;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ IdUser.GetHashCode();
                hash = (hash * 31) ^ IdSet.GetHashCode();

                return hash;
            }
        }
    }
}
