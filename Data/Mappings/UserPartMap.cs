using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UserPartMap : ClassMap<UserPart>
    {
        public UserPartMap()
        {
            Table("user_part");
            Id(x => x.Id).Column("id");

            References(x => x.User).Column("id_user");
            References(x => x.Part).Column("id_part");
        }
    }
}
