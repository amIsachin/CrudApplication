using BusinessEntity;
using BusinessLogics;
using ServicePrincipals;
using StudentServices;
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
        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                StudentEntityListBindingViewModel studentEntityListBindingViewModelObject = new StudentEntityListBindingViewModel();

                studentEntityListBindingViewModelObject.Title = "Index-page";
                studentEntityListBindingViewModelObject.Description = "Indexing Students Details";

                return View(studentEntityListBindingViewModelObject);
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        //[ChildActionOnly]
        public ActionResult Listing(string search)
        {
            try
            {
                StudentEntityListBindingViewModel studentEntityListBindingViewModel = new StudentEntityListBindingViewModel();

                studentEntityListBindingViewModel.Students = StudentServicePrincipals.Search(search, false);
                studentEntityListBindingViewModel.Title = "Listing";
                studentEntityListBindingViewModel.Description = "Ajax Listing";

                return PartialView(studentEntityListBindingViewModel);

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
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult Create(StudentEntity studentEntity)
        {
            try
            {
                if (StudentServicePrincipals.InsertStudent(studentEntity) is true)
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
                var record = StudentServicePrincipals.GetStudentByRollNumber(rollNumber);

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
                if (StudentServicePrincipals.UpdateStudent(studentEntity) is true)
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
                StudentEntityListBindingViewModel studentEntityListBindingViewModel = new StudentEntityListBindingViewModel();

                studentEntityListBindingViewModel.Students = StudentServicePrincipals.GetAllStudents();
                studentEntityListBindingViewModel.Title = "Students-Listing";
                studentEntityListBindingViewModel.Description = "All University Students";

                return View(studentEntityListBindingViewModel);
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
                StudentEntityBindingViewModel studentEntityBindingViewModel = new StudentEntityBindingViewModel();

                if (rollNumber > 0)
                {
                    studentEntityObject = StudentServicePrincipals.GetStudentByRollNumber(rollNumber);

                    studentEntityBindingViewModel.ID = studentEntityObject.ID;
                    studentEntityBindingViewModel.CreatedOn = studentEntityObject.CreatedOn;
                    studentEntityBindingViewModel.RollNumber = studentEntityObject.RollNumber;
                    studentEntityBindingViewModel.Name = studentEntityObject.Name;
                    studentEntityBindingViewModel.Class = studentEntityObject.Class;
                    studentEntityBindingViewModel.Gender = studentEntityObject.Gender;
                    studentEntityBindingViewModel.Age = studentEntityObject.Age;
                    studentEntityBindingViewModel.Fees = studentEntityObject.Fees;
                    studentEntityBindingViewModel.City = studentEntityObject.City;
                    studentEntityBindingViewModel.Address = studentEntityObject.Address;
                    studentEntityBindingViewModel.AdmissionSession = studentEntityObject.AdmissionSession;

                    studentEntityBindingViewModel.Title = "Updation-page";
                    studentEntityBindingViewModel.Description = "Modify Student Details Page";

                    return View(studentEntityBindingViewModel);
                }
                else
                {
                    studentEntityBindingViewModel.Title = "Creation-page";
                    studentEntityBindingViewModel.Description = "Registeration New Student Page";

                    return View(studentEntityBindingViewModel);
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
                            return RedirectToAction("StudentsListing");
                        }
                        else
                        {
                            return View();
                        }
                    }

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
                    return View(studentEntityBindingViewModel);
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