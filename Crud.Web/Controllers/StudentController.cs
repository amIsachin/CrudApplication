using BusinessEntity;
using BusinessLogics;
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
            try
            {
                return View();
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        public ActionResult Listing()
        {
            try
            {
                List<StudentEntity> record = _StudentsService.GetAllStudents().OrderByDescending(x => x.ID).Take(5).ToList();

                return PartialView(record);
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return PartialView();
            }
            catch (System.Exception ex)
            {
                ViewData["Message"] = ex.Message;
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult Create(StudentEntity studentEntity)
        {
            try
            {
                studentEntity.ID = CommonMethods.GenerateRandomNumber();
                studentEntity.AdmissionSession = CommonProperties.GetTime;
                bool isInserted = _StudentsService.InsertStudent(studentEntity);

                if (isInserted is true)
                {
                    TempData["InsertMessage"] = "Data has been Inserted Successfully";
                    return RedirectToAction("Listing");
                }
                else
                {
                    return View();
                }
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            try
            {
                var record = _StudentsService.GetAllStudents().Find(x => x.ID == ID);

                return PartialView(record);
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult Edit(StudentEntity studentEntity)
        {
            studentEntity.AdmissionSession = CommonProperties.GetTime;
            _StudentsService.UpdateStudent(studentEntity);
            return RedirectToAction("Listing");
        }

    }
}