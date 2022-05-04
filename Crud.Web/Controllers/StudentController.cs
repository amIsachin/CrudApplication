using BusinessEntity;
using BusinessLogics;
using ServicePrincipals;
using StudentServices;
using System.Collections.Generic;
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
        private StudentEntity studentEntityObject = new StudentEntity();
        private StudentEntityBindingViewModel studentEntityBindingViewModelObject = new StudentEntityBindingViewModel();
        private StudentEntityListBindingViewModel studentEntityListBindingViewModelObject = new StudentEntityListBindingViewModel();
        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                studentEntityListBindingViewModelObject.Title = "Listing";
                studentEntityListBindingViewModelObject.Description = "Ajax Listing";
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
                //List<StudentEntity> record = StudentServicePrincipals.Search(search, false);

                studentEntityListBindingViewModelObject.Students = StudentServicePrincipals.Search(search, false);
                studentEntityListBindingViewModelObject.Title = "Listing";
                studentEntityListBindingViewModelObject.Description = "Ajax Listing";
                return PartialView(studentEntityListBindingViewModelObject);

                //return PartialView(record);

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
                //bool isDeleted = _StudentsService.DeleteStudent(rollNumber);

                if (StudentServicePrincipals.PerformDelete(rollNumber) is true)
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
                studentEntityListBindingViewModelObject.Students = StudentServicePrincipals.GetAllStudents();
                studentEntityListBindingViewModelObject.Title = "Students";
                studentEntityListBindingViewModelObject.Description = "All University Students";

                return View(studentEntityListBindingViewModelObject);
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
                    studentEntityObject = StudentServicePrincipals.GetStudentByRollNumber(rollNumber);

                    studentEntityBindingViewModelObject.ID = studentEntityObject.ID;
                    studentEntityBindingViewModelObject.CreatedOn = studentEntityObject.CreatedOn;
                    studentEntityBindingViewModelObject.RollNumber = studentEntityObject.RollNumber;
                    studentEntityBindingViewModelObject.Name = studentEntityObject.Name;
                    studentEntityBindingViewModelObject.Class = studentEntityObject.Class;
                    studentEntityBindingViewModelObject.Gender = studentEntityObject.Gender;
                    studentEntityBindingViewModelObject.Age = studentEntityObject.Age;
                    studentEntityBindingViewModelObject.Fees = studentEntityObject.Fees;
                    studentEntityBindingViewModelObject.City = studentEntityObject.City;
                    studentEntityBindingViewModelObject.Address = studentEntityObject.Address;
                    studentEntityBindingViewModelObject.AdmissionSession = studentEntityObject.AdmissionSession;

                    return View(studentEntityBindingViewModelObject);
                }
                else
                {
                    return View(studentEntityBindingViewModelObject);
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