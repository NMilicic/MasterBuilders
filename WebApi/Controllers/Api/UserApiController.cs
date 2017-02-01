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
    public class UserApiController : ApiController
    {
        UserServices korisnikServices = new UserServices();


        public List<UserApi> GetAll(int take= -1, int offset = 0)
        {
            return korisnikServices.GetAll(take, offset).ProjectTo<UserApi>().ToList();
        }

        [HttpPost]
        public UserApi Login(LoginModel data)
        {
            if (string.IsNullOrEmpty(data.Email) || string.IsNullOrEmpty(data.Password))
                throw new UserException(UserException.UserExceptionsText(UserExceptionEnum.InvalidData));

            var user = Mapper.Map<UserApi>(korisnikServices.Login(data.Email, data.Password));

            return user;
        }


        [HttpPost]
        public UserApi Register(UserApi newUser)
        {
            if (!ModelState.IsValid)
                throw new UserException(UserException.UserExceptionsText(UserExceptionEnum.InvalidData));

            var newUserSaved = Mapper.Map<UserApi>(korisnikServices.Register(Mapper.Map<User>(newUser)));
            return newUserSaved;
        }
    }
}
