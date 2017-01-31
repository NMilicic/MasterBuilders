using AutoMapper;
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
    public class InventoryApiController : ApiController
    {
        UserSetService userSetServices = new UserSetService();

        [HttpGet]
        public List<UserLSetApi> GetAllForUser(int userId, int take = -1, int offset = 0)
        {
            var allSets = userSetServices.GetAllForUser(userId, take, offset).ToList();
            return Mapper.Map<List<UserLSetApi>>(allSets);
        }

        [HttpPost]
        public HttpResponseMessage AddSetsToInventory(List<UserLSetApi> userSets)
        {
            foreach (var userSet in userSets)
            {
                userSetServices.AddToInventory(userSet.UserId, userSet.SetId, userSet.Owned);
            }

            return Request.CreateResponse(HttpStatusCode.Created, "Sets added to inventory");
        }

        [HttpPost]
        public HttpResponseMessage RemoveSetsFromInventory(List<UserLSetApi> userSets)
        {
            foreach (var userSet in userSets)
            {
                userSetServices.RemoveFromInventory(userSet.UserId, userSet.SetId, userSet.Owned);
            }

            return Request.CreateResponse(HttpStatusCode.Created, "Sets removed from inventory");
        }

        [HttpPost]
        public HttpResponseMessage MarkSetsAsCompleted(List<UserLSetApi> userSets)
        {
            foreach (var userSet in userSets)
            {
                userSetServices.MarkSetAsCompleted(userSet.UserId, userSet.SetId, userSet.Built);
            }

            return Request.CreateResponse(HttpStatusCode.Created, "Sets removed from inventory");
        }

        [HttpGet]
        public List<UserLSetApi> Search(int userId, string searchParameters, int take = -1, int offset = 0)
        {
            var filteredSets = userSetServices.Search(userId, searchParameters, take, offset).ToList();
            return Mapper.Map<List<UserLSetApi>>(filteredSets);
        }
    }
}
