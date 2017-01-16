using AutoMapper.QueryableExtensions;
using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers.Api
{
    public class SetApiController : ApiController
    {
        LSetService setServices = new LSetService();

        [HttpGet]
        public List<SetApi> GetAll()
        {
            var tmp = setServices.GetAll().ProjectTo<SetApi>().ToList();
            return tmp;
        }
        [HttpGet]
        public List<SetApi> Search(string searchPattern)
        {
            var tmp = setServices.Search(searchPattern).ProjectTo<SetApi>().ToList();
            return tmp;
        }
    }
}
