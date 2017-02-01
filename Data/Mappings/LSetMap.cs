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

            Id(x => x.Id).Column("id").GeneratedBy.Native();
            Map(x => x.Name).Column("name");
            Map(x => x.ProductionYear).Column("production_year");
            Map(x => x.NumberOfParts).Column("num_parts");
            Map(x => x.Description).Column("description");
            Map(x => x.ThemeId).Column("id_theme");
            Map(x => x.InstructionsUrl).Column("instructions_url");
            Map(x => x.PictureUrl).Column("picture_url");

            References(x => x.Theme).Column("id_theme").ForeignKey("id");

            HasMany(x => x.UserLSets)
              .Table("user_Lset");

            HasMany(x => x.LSetParts)
              .Cascade.All()
              .Table("Lset_parts");
        }
    }
}
