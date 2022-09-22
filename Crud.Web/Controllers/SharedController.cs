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
        public JsonResult UploadImage(string imageUrl)
        {
            JsonResult jsonResult = new JsonResult();
            try
            {
                var picutres = Request.Files[0];

                var fileName = Guid.NewGuid() + Path.GetExtension(picutres.FileName);

                var path = Path.Combine(Server.MapPath(@"~/Content/ThemeMaterial/StudentResources/Images/") + fileName);

                picutres.SaveAs(path);

                jsonResult.Data = new { Success = true, ImageUrl = string.Format("/Content/ThemeMaterial/StudentResources/Images/{0}", fileName) };
            }
            catch (Exception ex)
            {
                jsonResult.Data = new { Success = false, ex.Message };
            }

            return jsonResult;
        }

        public FileResult Download()
        {
            string fileName = Path.GetFileName("fd300015-8625-47bc-8f56-666b145439c9.pdf");

            var path = Path.Combine(Server.MapPath(@"~/Content/ThemeMaterial/StudentResources/Images/") + fileName);

            string generatedFileName = Guid.NewGuid().ToString() + ".pdf";

            return File(path, @"image/png", generatedFileName);

            //return File(path, @"~/Content/ThemeMaterial/StudentResources/Images/png");

        }
    }
}