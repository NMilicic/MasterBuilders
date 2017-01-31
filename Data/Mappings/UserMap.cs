using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("users");

            Id(x => x.Id).Column("id");
            Map(x => x.Email).Column("email");
            Map(x => x.Password).Column("password");
            Map(x => x.FirstName).Column("first_name");
            Map(x => x.LastName).Column("last_name");

            HasManyToMany(x => x.Parts).Cascade.All().Table("user_part");
            HasMany(x => x.LSets).Cascade.All().Table("user_Lset");
            HasMany(x => x.Mocs).Cascade.All().Table("user_MOC");
            HasMany(x => x.Wishlists).Cascade.All().Table("wishlist");
        }
    }
}
