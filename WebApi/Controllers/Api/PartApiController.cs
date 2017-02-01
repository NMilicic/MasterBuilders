using AutoMapper;
using Business.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers.Api
{
    public class PartApiController : ApiController
    {
        PartService kockicaService = new PartService();

        [HttpGet]
        public List<PartApi> GetAll(int take = -1, int offset = 0)
        {
            var kockice = kockicaService.GetAll(take, offset).ToList();
            return Mapper.Map<List<PartApi>>(kockice);
        }

        [HttpGet]
        public List<PartApi> GetAllForUser(int userId, int take = -1, int offset = 0)
        {
            var kockice = kockicaService.GetAllForUser(userId, take, offset).ToList();
            return Mapper.Map<List<PartApi>>(kockice);
        }

        [HttpGet]
        public List<PartApi> Search(string searchParameters, int take = -1, int offset = 0)
        {
            var filteredSets = kockicaService.Search(searchParameters, take, offset).ToList();
            return Mapper.Map<List<PartApi>>(filteredSets);
        }
    }
}
