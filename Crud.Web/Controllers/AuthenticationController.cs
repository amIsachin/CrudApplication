using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult CreateAccount()
        {
            return View();
        }
    }
}