using Data.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class TemaMap : ClassMap<Tema>
    {
        public TemaMap()
        {
            Table("tema");

            Id(x => x.IdTema).Column("id_tema");
            Map(x => x.ImeTema).Column("ime_tema");

            References(x => x.NadTema).Column("id_nadtema");
        }
    }
}
