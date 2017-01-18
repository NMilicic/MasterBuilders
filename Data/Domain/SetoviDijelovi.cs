﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class SetoviDijelovi
    {
        public virtual int Id { get; set; }
        public virtual int Broj { get; set; }

        public virtual Boja Boja { get; set; }
        public virtual Kockica Kockica { get; set; }
        public virtual LSet Set { get; set; }
    }
}
