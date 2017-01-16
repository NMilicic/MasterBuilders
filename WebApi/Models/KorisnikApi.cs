using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class KorisnikApi
    {
        public  virtual int Id { get; set; }
        [Required]
        public virtual string Email { get; set; }
        [Required]
        public virtual string Zaporka { get; set; }
        [Required]
        public virtual string Ime { get; set;}
        [Required]
        public virtual string Prezime { get; set; }
    }
}
