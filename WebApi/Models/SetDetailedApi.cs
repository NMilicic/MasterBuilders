using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class SetDetailedApi : LSetApi
    {
        public List<LSetPartApi> LSetParts { get; set; }
    }
}