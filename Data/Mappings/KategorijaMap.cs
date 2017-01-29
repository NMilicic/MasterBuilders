using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class KategorijaMap : ClassMap<Kategorija>
    {
        public KategorijaMap()
        {
            Table("kategorija");

            Id(x => x.Id).Column("id");
            Map(x => x.Ime).Column("ime");

            HasMany(x => x.Kockice)
                .Cascade.All()
                .Inverse()
                .Table("Kockica")
                .KeyColumn("kategorija");
        }
    }
}
