using BusinessEntity;
using BusinessLogics;
using ServicePrincipals;
using StudentServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class StudentController : Controller
    {
        #region InitailizeDependencyInjectionInstance
        private readonly IStudentsService _StudentsService = null;
        private readonly StudentServicePrincipals StudentServicePrincipals = null;
        public StudentController(IStudentsService studentsService)
        {
            this._StudentsService = studentsService;
            this.StudentServicePrincipals = new StudentServicePrincipals(studentsService);
        }
        #endregion

        #region CreateObject
        private StudentEntity StudentEntityObject = new StudentEntity();
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

        public ActionResult Listing(string search)
        {
            try
            {
                List<StudentEntity> record = StudentServicePrincipals.Search(search, false);

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
        public ActionResult Edit(int rollNumber)
        {
            try
            {
                var record = _StudentsService.GetAllStudents().Find(x => x.RollNumber == rollNumber);

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
            try
            {
                studentEntity.AdmissionSession = CommonProperties.GetTime;
                bool isUpdated = _StudentsService.UpdateStudent(studentEntity);

                if (isUpdated is true)
                {
                    TempData["UpdateMessage"] = "Data has been updated successfuly";
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

        [HttpPost]
        public ActionResult Delete(int rollNumber)
        {
            try
            {
                bool isDeleted = _StudentsService.DeleteStudent(rollNumber);

                if (isDeleted is true)
                {
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
        public ActionResult StudentsListing()
        {
            try
            {
                List<StudentEntity> record = StudentServicePrincipals.GetAllStudents();

                return View(record);
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpGet]
        public ActionResult Actions(int? rollNumber)
        {
            try
            {
                if (rollNumber > 0)
                {
                    StudentEntityObject = StudentServicePrincipals.GetStudentByRollNumber(rollNumber);

                    return View(StudentEntityObject);
                }
                else
                {
                    return View(StudentEntityObject);
                }
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult Actions(StudentEntity studentEntity)
        {
            try
            {
                if (Request.IsAjaxRequest())
                {
                    if (StudentServicePrincipals.PerformDelete(studentEntity.RollNumber) is true)
                    {
                        return RedirectToAction("StudentsListing");
                    }
                    else
                    {
                        return View();
                    }
                }

                studentEntity.AdmissionSession = CommonProperties.GetTime;

                if (StudentServicePrincipals.PerformActions(studentEntity) is true)
                {
                    return RedirectToAction("StudentsListing");
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

        [HttpPost]
        public JsonResult AutoSearch(string search)
        {
            JsonResult json = new JsonResult();
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchItem(string search)
        {
            JsonResult jsonResult = new JsonResult();
            var record = _StudentsService.GetAllStudents().Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();

            jsonResult.Data = new { Success = true, Response = record };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

    }
}