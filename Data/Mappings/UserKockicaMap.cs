using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UserKockicaMap : ClassMap<UserKockica>
    {
        public UserKockicaMap()
        {
            Table("user_set");
            Id(x => x.Id).Column("id");

            References(x => x.Korisnik).Column("id_usr");
            References(x => x.Kockica).Column("id_koc");
        }
    }
}
