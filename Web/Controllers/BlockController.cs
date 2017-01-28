using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Services;
using Data.Domain;

namespace Web.Controllers
{
    public class BlockController : Controller
    {
        public ActionResult SetParts(int setId)
        {
            LSetService setService = new LSetService();

            LSet set = setService.GetById(setId);
           
            return View(set);
        }
    }
}