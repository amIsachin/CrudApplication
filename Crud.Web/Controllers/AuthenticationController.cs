using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }


    }
}