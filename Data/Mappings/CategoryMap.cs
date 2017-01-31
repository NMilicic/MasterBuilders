using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("category");

            Id(x => x.Id).Column("id");
            Map(x => x.Name).Column("name");

            HasMany(x => x.Parts)
                .Cascade.All()
                .Inverse()
                .Table("part")
                .KeyColumn("category");
        }
    }
}
