using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class MocDijeloviMap : ClassMap<MocDijelovi>
    {
        public MocDijeloviMap()
        {
            Table("MOC_dijelovi");
            Id(x => x.Id).Column("id");

            References(x => x.Boja).Column("id_boja").ForeignKey("id");
            References(x => x.Moc).Column("id_set").ForeignKey("id");
            References(x => x.Kockica).Column("id_koc").ForeignKey("id");
        }
    }
}
