using StudentServices;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class StudentController : Controller
    {
        #region InitailizeInstance
        private IStudentsService _StudentsService = null;
        public StudentController(IStudentsService studentsService)
        {
            _StudentsService = studentsService;
        }
        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            string Name = _StudentsService.GetName();
            return View();
        }

        public ActionResult Listing()
        {
            return PartialView();
        }
    }
}