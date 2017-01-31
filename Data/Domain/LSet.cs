using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class LSet
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int ProductionYear { get; set; }
        public virtual int NumberOfParts { get; set; }
        public virtual string Description { get; set; }
        public virtual int ThemeId { get; set; }
        public virtual string SetCode { get; set; }
        public virtual string InstructionsUrl { get; set; }
        public virtual string PictureUrl { get; set; }

        public virtual Theme Theme { get; set; }
        public virtual IEnumerable<UserLSet> UserLSets { get; set; }
        public virtual IEnumerable<LSetPart> LSetParts { get; set; }

        public LSet()
        {
            UserLSets = new List<UserLSet>();
            LSetParts = new List<LSetPart>();
        }
    }
}
