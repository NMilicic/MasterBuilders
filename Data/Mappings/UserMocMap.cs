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
            Id(x => x.Id).Column("id");

            Map(x => x.Slozeno).Column("slozeno");

            References(x => x.Korisnik).Column("Korisnik_id");
            References(x => x.Moc).Column("id_moc");
        }
    }
}
