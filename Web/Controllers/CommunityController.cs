using Business.Services;
using Data.Domain;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CommunityController : Controller
    {
        UserServices userService = new UserServices();
        UserSetService userSetService = new UserSetService();
        // GET: Community
        public ActionResult Index()
        {
            var users = userService.GetAll();
            ViewBag.listItems = users;

            return View();
        }

        public ActionResult Profile(string userId)
        {
            var sets = userSetService.GetAllForUser(int.Parse(userId));
            ViewBag.listItems = sets;
            User korisnik = userService.GetById(int.Parse(userId));

            return View(korisnik);
        }
    }
}