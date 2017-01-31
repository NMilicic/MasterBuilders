﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class Wishlist
    {
        public virtual int Id { get; set; }
        public virtual int Number { get; set; }

        public virtual User User { get; set; }
        public virtual LSet LSet { get; set; }
    }
}
