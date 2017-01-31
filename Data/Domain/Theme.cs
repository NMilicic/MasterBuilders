using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Theme
    {
        public virtual int Id { get; set; }
        public virtual int BaseThemeId { get; set; }
        public virtual string Name { get; set; }

        public virtual Theme BaseTheme { get; set; }
    }
}
