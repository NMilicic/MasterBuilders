﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class WishlistApi
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int UserId { get; set; }
        public int LSetId { get; set; }
        public LSetApi LSet { get; set; }
    }
}