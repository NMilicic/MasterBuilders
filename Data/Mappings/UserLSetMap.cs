using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UserLSetMap : ClassMap<UserLSet>
    {
        public UserLSetMap()
        {
            Table("user_Lset");
            Id(x => x.Id).Column("id");

            Map(x => x.Built).Column("built");
            Map(x => x.Owned).Column("owned");

            References(x => x.User).Column("id_user");
            References(x => x.LSet).Column("id_Lset");
        }
    }
}
