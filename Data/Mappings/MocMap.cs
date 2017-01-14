using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class MocMap : ClassMap<Moc>
    {
        public MocMap()
        {
            Table("MOC");

            Id(x => x.Id).Column("id");
            Map(x => x.Ime).Column("ime");
            Map(x => x.DijeloviBroj).Column("dijelovi_broj");
            Map(x => x.Tema1).Column("tema1");
            Map(x => x.Tema2).Column("tema2");
            Map(x => x.Tema3).Column("tema3");
            Map(x => x.Opis).Column("opis");
            Map(x => x.IdAutor).Column("id_autor");
            Map(x => x.GodinaProizvodnje).Column("god_pro");

            References(x => x.Autor).Column("id_autor").ForeignKey("id");
            HasMany(x => x.Dijelovi).Cascade.All().Table("MOC_dijelovi");
        }
    }
}
