﻿using Data.Domain;
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
            Map(x => x.Name).Column("name");
            Map(x => x.NumberOfParts).Column("num_parts");
            Map(x => x.Theme1).Column("theme1");
            Map(x => x.Theme2).Column("theme2");
            Map(x => x.Theme3).Column("theme3");
            Map(x => x.Description).Column("description");
            Map(x => x.AuthorId).Column("id_author");
            Map(x => x.ProductionYear).Column("production_year");

            References(x => x.UserMoc).Column("id_author").ReadOnly();
            HasMany(x => x.MocParts).Cascade.All().Table("MOC_parts");
        }
    }
}
