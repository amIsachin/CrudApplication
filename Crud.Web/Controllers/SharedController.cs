using System;
using System.Collections.Generic;
using System.IO;
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
            var picutres = Request.Files[0];

            var fileName = Guid.NewGuid() + Path.GetExtension(picutres.FileName);

            var path = Path.Combine(Server.MapPath(@"~/Content/ThemeMaterial/StudentResources/Images/") + fileName);

            picutres.SaveAs(path);
            

            return View();
        }
    }
}