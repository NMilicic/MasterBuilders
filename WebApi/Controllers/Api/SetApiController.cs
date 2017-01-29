﻿using AutoMapper;
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
        public List<SetApi> GetAll(int take = -1, int offset = 0)
        {
            var allSets = setServices.GetAll(take, offset).ToList();
            return Mapper.Map<List<SetApi>>(allSets);
        }

        [HttpGet]
        public SetDetailedApi GetDetailedSet(int id)
        {
            var set = setServices.GetById(id);
            return Mapper.Map<SetDetailedApi>(set);
        }

        [HttpGet]
        public List<SetApi> GetSetsWithBricks([FromUri] int[] ids, int take = -1, int offset = 0)
        {
            var sets = setServices.GetAllSetsWithBricks(ids.ToList(), take, offset).ToList();

            return Mapper.Map<List<SetApi>>(sets);
        }
        [HttpGet]
        public List<SetApi> Search(string searchParameters, int take = -1, int offset = 0)
        {
            var filteredSets = setServices.Search(searchParameters, take, offset).ToList();
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
