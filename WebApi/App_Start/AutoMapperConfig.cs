using AutoMapper;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
               cfg.CreateMap<Korisnik, KorisnikApi>();

            });

        }
    }
}