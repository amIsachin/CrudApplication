﻿using BusinessEntity;
using BusinessLogics;
using ServicePrincipals;
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
        private readonly StudentServicePrincipals StudentServicePrincipals = null;
        //--> private IStudentEntity _StudentEntity = null;
        public StudentController(IStudentsService studentsService)  //--> IStudentEntity studentEntity
        {
            this._StudentsService = studentsService;
            this.StudentServicePrincipals = new StudentServicePrincipals(studentsService);
            //--> this._StudentEntity = studentEntity;
        }
        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            string Name = "Delhi";
            var record = StudentServicePrincipals.Search(Name);

            try
            {
                return View();
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpGet]
        public JsonResult Search(string search)
        {
            JsonResult json = new JsonResult();
            try
            {
                var record = _StudentsService.GetAllStudents().Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
                json.Data = new { Success = true, Response = record };
            }
            catch (System.Exception ex)
            {
                json.Data = new { Success = false, Message = ex.Message };
            }
            return Json(json, JsonRequestBehavior.AllowGet);

            //--> result.Data = new { Success = true, ImageURL = string.Format("/Content/Images/{0}", fileName) };
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

    }
}