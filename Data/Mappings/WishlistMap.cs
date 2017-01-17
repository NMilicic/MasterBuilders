using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class WishlistMap : ClassMap<Wishlist>
    {
        public WishlistMap()
        {
            Table("wishlist");
            Id(x => x.Id).Column("id");

            Map(x => x.Komada).Column("Komada");

            References(x => x.Korisnik).Column("Korisnik_id");
            References(x => x.Set).Column("LSet_id");
        }
    }
}
