using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class KorisnikMap : ClassMap<Korisnik>
    {
        public KorisnikMap()
        {
            Table("Korisnik");

            Id(x => x.Id).Column("id");
            Map(x => x.Email).Column("email");
            Map(x => x.Zaporka).Column("zaporka");
            Map(x => x.Ime).Column("ime");
            Map(x => x.Prezime).Column("prezime");

            HasManyToMany(x => x.Kockice).Cascade.All().Table("user_kockica");
            HasMany(x => x.Setovi).Cascade.All().Table("user_set");
            HasMany(x => x.Moc).Cascade.All().Table("user_MOC");
        }
    }
}
