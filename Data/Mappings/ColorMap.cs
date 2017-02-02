using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class ColorMap : ClassMap<Color>
    {
        public ColorMap()
        {
            Table("color");

            Id(x => x.Id).Column("id").GeneratedBy.Native();
            Map(x => x.Name).Column("name");

            HasMany(x => x.LSetParts)
             .Cascade.All()
             .Inverse()
             .Table("lset_parts");

            HasMany(x => x.MocParts)
                 .Cascade.All()
                 .Inverse()
                 .Table("MOC_parts");
        }
    }
}
