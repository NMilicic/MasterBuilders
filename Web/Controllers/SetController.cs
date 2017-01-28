using Business.Services;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class SetController : Controller
    {
        // GET: Set/Details
        public ActionResult Details(int setId)
        {
            Debug.WriteLine("id " + setId);
            LSetService setService = new LSetService();
            LSet set = setService.GetById(setId);
            return View(set);
        }
    }
}