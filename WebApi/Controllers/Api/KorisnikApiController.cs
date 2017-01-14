using Business.Services;
using Data.Domain;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace WebApi.Controllers.Api
{
    public class KorisnikApiController : ApiController
    {
        KorisnikServices korisnikServices = new KorisnikServices();
        public List<KorisnikApi> GetAll()
        {
            return korisnikServices.GetAll().ProjectTo<KorisnikApi>().ToList();
        }
    }
}
