using Business.Services;
using Data.Domain;
using System;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CommunityController : Controller
    {
        KorisnikServices korisnikServices = new KorisnikServices();
        UserSetService userSetService = new UserSetService();
        // GET: Community
        public ActionResult Index()
        {
            var users = korisnikServices.GetAll();
            ViewBag.users = users;

            return View();
        }

        public ActionResult Profile(string userId)
        {
            var sets = userSetService.GetAllForUser(Int32.Parse(userId));
            ViewBag.sets = sets;
            User korisnik = korisnikServices.GetById(Int32.Parse(userId));

            return View(korisnik);
        }
    }
}