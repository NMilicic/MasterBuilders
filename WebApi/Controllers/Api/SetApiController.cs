using AutoMapper;
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
            var allSets = setServices.GetAll().ToList();
            return Mapper.Map<List<SetApi>>(allSets);
        }

        [HttpGet]
        public List<SetApi> GetSet()
        {
            var tmp = setServices.GetAll().ProjectTo<SetApi>().ToList();
            return tmp;
        }
        [HttpGet]
        public List<SetApi> Search(string searchPattern)
        {
            var filteredSets = setServices.Search(searchPattern).ToList();;
            return Mapper.Map<List<SetApi>>(filteredSets);
        }

        [HttpPost]
        public HttpResponseMessage AddSetsToInventory(List<UserSetApi> userSets)
        {
            foreach (var userSet in userSets)
            {
                setServices.AddToInventory(userSet.IdUser, userSet.IdSet, userSet.Komada);
            }

            return Request.CreateResponse(HttpStatusCode.Created, "Sets added to inventroy");
        }
    }
}
