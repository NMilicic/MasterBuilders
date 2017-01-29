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
        public MocApi AddDijeloviToMoc(MocApi mocToUpdate)
        {
            var moc = mocService.AddDijeloviMoc(mocToUpdate.Id, Mapper.Map<List<MocDijelovi>>(mocToUpdate.Dijelovi));
            return Mapper.Map<MocApi>(moc);
        }
    }
}
