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
        public List<KockicaApi> GetAll()
        {
            var kockice = kockicaService.GetAll().ToList();
            return Mapper.Map<List<KockicaApi>>(kockice);
        }

        [HttpGet]
        public List<KockicaApi> GetAllForUser(int userId)
        {
            var kockice = kockicaService.GetAllForUser(userId).ToList();
            return Mapper.Map<List<KockicaApi>>(kockice);
        }
    }
}
