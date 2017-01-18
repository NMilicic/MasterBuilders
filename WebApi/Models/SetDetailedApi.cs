using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class SetDetailedApi : SetApi
    {
        public List<SetDijeloviApi> Dijelovi { get; set; }
    }
}