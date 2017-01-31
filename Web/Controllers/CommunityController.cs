using Business.Services;
using Data.Domain;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CommunityController : Controller
    {
        KorisnikServices userService = new KorisnikServices();
        UserSetService userSetService = new UserSetService();
        // GET: Community
        public ActionResult Index()
        {
            var users = userService.GetAll();
            ViewBag.users = users;

            return View();
        }

        public ActionResult Profile(string userId)
        {
            var sets = userSetService.GetAllForUser(int.Parse(userId));
            ViewBag.sets = sets;
            User korisnik = userService.GetById(int.Parse(userId));

            return View(korisnik);
        }
    }
}