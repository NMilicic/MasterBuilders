using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UserMocMap : ClassMap<UserMoc>
    {
        public UserMocMap()
        {
            Table("user_MOC");
            Id(x => x.Id).Column("id").GeneratedBy.Native();

            Map(x => x.Built).Column("built");

            References(x => x.User).Column("id_user");
            References(x => x.Moc).Column("id_moc");
        }
    }
}
