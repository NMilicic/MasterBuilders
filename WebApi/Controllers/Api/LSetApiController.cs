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
    public class LSetApiController : ApiController
    {
        LSetService setServices = new LSetService();

        [HttpGet]
        public List<LSetApi> GetAll(int take = -1, int offset = 0)
        {
            var allSets = setServices.GetAll(take, offset).ToList();
            return Mapper.Map<List<LSetApi>>(allSets);
        }

        [HttpGet]
        public SetDetailedApi GetDetailedSet(int id)
        {
            var set = setServices.GetById(id);
            return Mapper.Map<SetDetailedApi>(set);
        }

        [HttpGet]
        public List<LSetApi> GetSetsWithBricks([FromUri] int[] ids, int take = -1, int offset = 0)
        {
            var sets = setServices.GetAllSetsWithBricks(ids.ToList(), take, offset).ToList();

            return Mapper.Map<List<LSetApi>>(sets);
        }
        [HttpGet]
        public List<LSetApi> Search(string searchParameters, int take = -1, int offset = 0)
        {
            var filteredSets = setServices.Search(searchParameters, take, offset).ToList();
            return Mapper.Map<List<LSetApi>>(filteredSets);
        }

        [HttpGet]
        public List<LSetApi> BuilderAssistend(int userId)
        {
            var possibleSets = setServices.BuilderAssistent(userId);
            return Mapper.Map<List<LSetApi>>(possibleSets);
        }
    }
}
