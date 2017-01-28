using Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        KorisnikServices korisnikServices = new KorisnikServices();
        public ActionResult Index()
        {
            var tmp = korisnikServices.GetAll();
            return View();
        }
    }
}