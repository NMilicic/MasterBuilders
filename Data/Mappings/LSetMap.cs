using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class LSetMap : ClassMap<LSet>
    {
        public LSetMap()
        {
            Table("Lset");

            Id(x => x.Id).Column("id");
            Map(x => x.Ime).Column("ime");
            Map(x => x.GodinaProizvodnje).Column("god_pro");
            Map(x => x.DijeloviBroj).Column("dijelovi_broj");
            Map(x => x.Opis).Column("opis");
            Map(x => x.IdTema).Column("id_tema");

            References(x => x.Tema).Column("id_tema").ForeignKey("id");

            HasMany(x => x.KorisnikSet)
              .Cascade.All()
              .Inverse()
              .Table("user_set");
        }
    }
}
