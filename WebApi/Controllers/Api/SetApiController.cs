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
        public SetDetailedApi GetDetailedSet(int id)
        {
            var set = setServices.GetById(id);
            return Mapper.Map<SetDetailedApi>(set);
        }

        [HttpGet]
        public List<SetApi> GetSetsWithBricks([FromUri] int[] ids)
        {
            var sets = setServices.GetAllSetsWithBricks(ids.ToList()).ToList();

            return Mapper.Map<List<SetApi>>(sets);
        }
        [HttpGet]
        public List<SetApi> Search(string searchParameters)
        {
            var filteredSets = setServices.Search(searchParameters).ToList();
            return Mapper.Map<List<SetApi>>(filteredSets);
        }

        [HttpGet]
        public List<SetApi> BuilderAssistend(int userId)
        {
            var possibleSets = setServices.BuilderAssistent(userId);
            return Mapper.Map<List<SetApi>>(possibleSets);
        }
    }
}
