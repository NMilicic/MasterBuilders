using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class KockicaMap : ClassMap<Kockica>
    {
        public KockicaMap()
        {
            Table("kockica");

            Id(x => x.Id).Column("id");
            Map(x => x.Ime).Column("ime");
            Map(x => x.Kategorija).Column("kategorija");

            HasManyToMany(x => x.Korisnik)
              .Cascade.All()
              .Inverse()
              .Table("user_kockica");

            HasMany(x => x.SetoviDijelovi)
             .Cascade.All()
             .Inverse()
             .Table("setovi_dijelovi");
        }
    }
}
