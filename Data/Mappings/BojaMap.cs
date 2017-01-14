using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class BojaMap : ClassMap<Boja>
    {
        public BojaMap()
        {
            Table("boja");

            Id(x => x.Id).Column("id");
            Map(x => x.Ime).Column("ime");

            HasMany(x => x.SetoviDijelovi)
             .Cascade.All()
             .Inverse()
             .Table("setovi_dijelovi");

            HasMany(x => x.MocDijelovi)
                 .Cascade.All()
                 .Inverse()
                 .Table("MOC_dijelovi");
        }
    }
}
