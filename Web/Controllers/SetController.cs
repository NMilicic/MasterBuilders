using Business.Services;
using Data.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class SetController : Controller
    {
        LSetService setService = new LSetService();
        UserSetService userSetService = new UserSetService();

        // GET: Set/Details
        public ActionResult Details(int setId)
        {
            Debug.WriteLine("id " + setId);
            LSet set = setService.GetById(setId);
            return View(set);
        }

        
    }
}