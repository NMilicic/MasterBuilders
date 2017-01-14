using Business.Services;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            KorisnikServices service = new KorisnikServices();

             var tmp =service.KorisnikTestMethod();

            var tmp1 = service.SetTestMethod();
            var tmp2 = service.MocTestMethod();
            return View();
        }
    }
}
