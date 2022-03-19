using BusinessEntity;
using StudentServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class StudentController : Controller
    {
        #region InitailizeInstance
        private readonly IStudentsService _StudentsService = null;
        //--> private IStudentEntity _StudentEntity = null;
        public StudentController(IStudentsService studentsService)  //--> IStudentEntity studentEntity
        {
            this._StudentsService = studentsService;
            //--> this._StudentEntity = studentEntity;
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

        [HttpGet]
        public ActionResult Create()
        {
            //return PartialView();
            return HttpNotFound();
        }
    }
}