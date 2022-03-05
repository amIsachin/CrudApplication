using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listing()
        {
            return PartialView();
        }
    }
}