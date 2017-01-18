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
            Map(x => x.Broj).Column("broj");

            References(x => x.Boja).Column("id_boja");
            References(x => x.Moc).Column("id_set");
            References(x => x.Kockica).Column("id_koc");
        }
    }
}
