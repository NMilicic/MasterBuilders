using AutoMapper;
using Business.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers.Api
{
    public class KockicaApiController : ApiController
    {
        KockiceService kockicaService = new KockiceService();

        [HttpGet]
        public List<KockicaApi> GetAll(int take = -1, int offset = 0)
        {
            var kockice = kockicaService.GetAll(take, offset).ToList();
            return Mapper.Map<List<KockicaApi>>(kockice);
        }

        [HttpGet]
        public List<KockicaApi> GetAllForUser(int userId, int take = -1, int offset = 0)
        {
            var kockice = kockicaService.GetAllForUser(userId, take, offset).ToList();
            return Mapper.Map<List<KockicaApi>>(kockice);
        }
    }
}
