using Business.Services;
using Data.Domain;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using System.Linq;
using Business.Exceptions;
using WebApi.Models;

namespace WebApi.Controllers.Api
{
    public class KorisnikApiController : ApiController
    {
        KorisnikServices korisnikServices = new KorisnikServices();


        public List<KorisnikApi> GetAll(int take= -1, int offset = 0)
        {
            return korisnikServices.GetAll(take, offset).ProjectTo<KorisnikApi>().ToList();
        }

        [HttpPost]
        public KorisnikApi Login(LoginModel data)
        {
            if (string.IsNullOrEmpty(data.Email) || string.IsNullOrEmpty(data.Zaporka))
                throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.InvalidData));

            var user = Mapper.Map<KorisnikApi>(korisnikServices.Login(data.Email, data.Zaporka));

            return user;
        }


        [HttpPost]
        public KorisnikApi Register(KorisnikApi newUser)
        {
            if (!ModelState.IsValid)
                throw new KorisnikException(KorisnikException.KorisnikExceptionsText(KorisnikExceptionEnum.InvalidData));

            var newUserSaved = Mapper.Map<KorisnikApi>(korisnikServices.Register(Mapper.Map<Korisnik>(newUser)));
            return newUserSaved;
        }
    }
}
