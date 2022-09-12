using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class SharedController : Controller
    {
        [HttpPost]
        public ActionResult UploadImage(string imageUrl)
        {
            return View();
        }
    }
}