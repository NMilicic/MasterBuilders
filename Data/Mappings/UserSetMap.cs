using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UserSetMap : ClassMap<UserSet>
    {
        public UserSetMap()
        {
            Table("user_set");
            Id(x => x.Id).Column("id");

            Map(x => x.Slozeno).Column("slozeno");

            References(x => x.Korisnik).Column("Korisnik_id");
            References(x => x.Set).Column("LSet_id");
        }
    }
}
