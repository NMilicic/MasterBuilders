using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class UserApi
    {
        public  virtual int Id { get; set; }
        [Required]
        public virtual string Email { get; set; }
        [Required]
        public virtual string Password { get; set; }
        [Required]
        public virtual string FirstName { get; set;}
        [Required]
        public virtual string LastName { get; set; }
    }
}
