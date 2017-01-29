using Business.Services;
using Data.Domain;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class SetController : Controller
    {
        LSetService setService = new LSetService();
        UserSetService userSetService = new UserSetService();

        // GET: Set/Details
        public ActionResult Details(int setId)
        {
            LSet set = setService.GetById(setId);
            return View(set);
        }

        
    }
}