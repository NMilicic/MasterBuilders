using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class UserLSetApi
    {
        public  int Id { get; set; }
        public  int UserId { get; set; }
        public  int SetId { get; set; }
        public  int Built { get; set; }
        public int Owned { get; set; }

        public  UserApi User { get; set; }
        public  LSetApi LSet { get; set; }
    }
}