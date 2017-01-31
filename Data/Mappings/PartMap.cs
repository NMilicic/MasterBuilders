using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class PartMap : ClassMap<Part>
    {
        public PartMap()
        {
            Table("part");

            Id(x => x.Id).Column("id");
            Map(x => x.Name).Column("name");
            Map(x => x.PictureUrl).Column("picture_url");

            References(x => x.Category).Column("category");

            HasManyToMany(x => x.Users)
              .Cascade.All()
              .Inverse()
              .Table("user_part");

            HasMany(x => x.LSetParts)
             .Cascade.All()
             .Inverse()
             .Table("Lsets_parts");
        }
    }
}
