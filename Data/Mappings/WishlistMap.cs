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
            Id(x => x.Id).Column("id").GeneratedBy.Native();

            Map(x => x.Number).Column("num");

            References(x => x.User).Column("id_user");
            References(x => x.LSet).Column("id_LSet");
        }
    }
}
