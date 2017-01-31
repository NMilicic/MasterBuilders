using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class MocPartMap : ClassMap<MocPart>
    {
        public MocPartMap()
        {
            Table("MOC_parts");
            Id(x => x.Id).Column("id");
            Map(x => x.Number).Column("num");

            References(x => x.Color).Column("id_color");
            References(x => x.Moc).Column("id_set");
            References(x => x.Part).Column("id_part");
        }
    }
}
