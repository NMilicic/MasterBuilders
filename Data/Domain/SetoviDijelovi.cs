using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class SetoviDijelovi
    {
        public virtual int Id { get; set; }
        public virtual int IdBoja { get; set; }
        public virtual int IdKockica { get; set; }
        public virtual int IdSet { get; set; }
        public virtual int Broj { get; set; }

        public virtual Boja Boja { get; set; }
        public virtual Kockica Kockica { get; set; }
        public virtual LSet Set { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as SetoviDijelovi;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.IdBoja == other.IdBoja &&
                this.IdKockica == other.IdKockica && this.IdSet == other.IdSet;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ IdBoja.GetHashCode();
                hash = (hash * 31) ^ IdKockica.GetHashCode();
                hash = (hash * 31) ^ IdSet.GetHashCode();

                return hash;
            }
        }
    }
}
