using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class UserSetApi
    {
        public  int Id { get; set; }
        public  int IdUser { get; set; }
        public  int IdSet { get; set; }
        public  int Slozeno { get; set; }
        public int Komada { get; set; }

        public  KorisnikApi Korisnik { get; set; }
        public  SetApi Set { get; set; }
    }
}