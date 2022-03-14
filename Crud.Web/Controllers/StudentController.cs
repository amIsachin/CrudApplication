using BusinessEntity;
using StudentServices;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        public ActionResult Listing()
        {
            List<StudentEntity> record = _StudentsService.GetAllStudents().ToList();

            return PartialView(record);
        }
    }
}