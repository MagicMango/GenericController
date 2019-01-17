using System.Web.Mvc;

namespace AGenericController.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}