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
        public List<SetApi> GetAllForUser(int userId)
        {
            var allSets = userSetServices.GetAllForUser(userId).ToList();
            return Mapper.Map<List<SetApi>>(allSets);
        }

        [HttpPost]
        public HttpResponseMessage AddSetsToInventory(List<UserSetApi> userSets)
        {
            foreach (var userSet in userSets)
            {
                userSetServices.AddToInventory(userSet.IdUser, userSet.IdSet, userSet.Komada);
            }

            return Request.CreateResponse(HttpStatusCode.Created, "Sets added to inventory");
        }

        [HttpPost]
        public HttpResponseMessage RemoveSetsFromInventory(List<UserSetApi> userSets)
        {
            foreach (var userSet in userSets)
            {
                userSetServices.RemoveFromInventory(userSet.IdUser, userSet.IdSet, userSet.Komada);
            }

            return Request.CreateResponse(HttpStatusCode.Created, "Sets removed from inventory");
        }

        [HttpPost]
        public HttpResponseMessage MarkSetsAsCompleted(List<UserSetApi> userSets)
        {
            foreach (var userSet in userSets)
            {
                userSetServices.MarkSetAsCompleted(userSet.IdUser, userSet.IdSet, userSet.Slozeno);
            }

            return Request.CreateResponse(HttpStatusCode.Created, "Sets removed from inventory");
        }
    }
}
