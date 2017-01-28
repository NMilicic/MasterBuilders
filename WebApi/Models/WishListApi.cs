using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class WishlistApi
    {
        public int Id { get; set; }
        public int Komada { get; set; }
        public int KorisnikId { get; set; }
        public int SetId { get; set; }
        public SetApi Set { get; set; }
    }
}