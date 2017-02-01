using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Services;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers.Api
{
    public class MocApiController : ApiController
    {
        MOCService mocService = new MOCService();
        public List<MocApi> GetAllByAuthor(int authorId, int take = -1, int offset = 0)
        {
            var mocs = mocService.GetAllByAuthor(authorId, take, offset).ToList();
            return Mapper.Map<List<MocApi>>(mocs);
        }

        [HttpPost]
        public MocApi AddNewMoc(MocApi newMoc)
        {
            var moc = mocService.AddMoc(AutoMapper.Mapper.Map<Moc>(newMoc));
            return Mapper.Map<MocApi>(moc);
        }

        [HttpPost]
        public MocApi AddPartToMoc(MocApi mocToUpdate)
        {
            var moc = mocService.AddMocPartToMoc(mocToUpdate.Id, Mapper.Map<List<MocPart>>(mocToUpdate.MocParts));
            return Mapper.Map<MocApi>(moc);
        }
        [HttpGet]
        public List<LSetApi> Search(string searchParameters, int take = -1, int offset = 0)
        {
            var filteredSets = mocService.Search(searchParameters, take, offset).ToList();
            return Mapper.Map<List<LSetApi>>(filteredSets);
        }
    }
}
