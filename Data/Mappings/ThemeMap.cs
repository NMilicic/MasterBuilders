using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class ThemeMap : ClassMap<Theme>
    {
        public ThemeMap()
        {
            Table("theme");

            Id(x => x.Id).Column("id_theme").GeneratedBy.Native();
            Map(x => x.Name).Column("name_theme");

            References(x => x.BaseTheme).Column("id_basetheme");
        }
    }
}
