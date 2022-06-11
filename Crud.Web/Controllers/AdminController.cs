using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult ControlPanel()
        {
            return View();
        }
    }
}