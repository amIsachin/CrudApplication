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
using ViewModels;

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
        private StudentEntityBindingViewModel StudentEntityBindingViewModel = new StudentEntityBindingViewModel();
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

                    StudentEntityBindingViewModel.ID = StudentEntityObject.ID;
                    StudentEntityBindingViewModel.CreatedOn = StudentEntityObject.CreatedOn;
                    StudentEntityBindingViewModel.RollNumber = StudentEntityObject.RollNumber;
                    StudentEntityBindingViewModel.Name = StudentEntityObject.Name;
                    StudentEntityBindingViewModel.Class = StudentEntityObject.Class;
                    StudentEntityBindingViewModel.Gender = StudentEntityObject.Gender;
                    StudentEntityBindingViewModel.Age = StudentEntityObject.Age;
                    StudentEntityBindingViewModel.Fees = StudentEntityObject.Fees;
                    StudentEntityBindingViewModel.City = StudentEntityObject.City;
                    StudentEntityBindingViewModel.Address = StudentEntityObject.Address;
                    StudentEntityBindingViewModel.AdmissionSession = StudentEntityObject.AdmissionSession;

                    return View(StudentEntityBindingViewModel);
                }
                else
                {
                    return View(StudentEntityBindingViewModel);
                }
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult Actions(StudentEntityBindingViewModel studentEntityBindingViewModel)
        {
            try
            {
                if (ModelState.IsValid is true)
                {
                    if (Request.IsAjaxRequest())
                    {
                        if (StudentServicePrincipals.PerformDelete(studentEntityBindingViewModel.RollNumber) is true)
                        {
                            TempData["DeleteMessage"] = "Student Deleted Successfully";
                            return RedirectToAction("StudentsListing");
                        }
                        else
                        {
                            return View();
                        }
                    }

                    studentEntityBindingViewModel.AdmissionSession = CommonProperties.GetTime;

                    if (StudentServicePrincipals.PerformActions(studentEntityBindingViewModel) is true)
                    {
                        if (CommonVariables.AlertMessage is true)
                        {
                            TempData["UpdatedMessage"] = "Data has been Created successfully";
                        }
                        else
                        {
                            TempData["CreateMessage"] = "Data has been Updated successfully";
                        }

                        return RedirectToAction("StudentsListing");
                    }
                    else
                    {
                        return View();
                    }
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
            //json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var searchRecord = StudentServicePrincipals.Search(search, true);
            //json.Data = new { Success = true, Response = searchRecord };
            return Json(searchRecord, JsonRequestBehavior.AllowGet);
        }

    }
}