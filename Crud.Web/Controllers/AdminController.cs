﻿using ServicePrincipals;
using StudentServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        #region InitializeDependencyInjectionInstance
        private readonly IUniversityStudentService _UniversityStudentService = null;
        private readonly UniversityStudentServicePrincipal _UniversityStudentServicePrincipal = null;
        public AdminController(IUniversityStudentService universityStudentService)
        {
            this._UniversityStudentService = universityStudentService;
            this._UniversityStudentServicePrincipal = new UniversityStudentServicePrincipal(universityStudentService);
        }
        #endregion

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        //[Authorize]
        public async Task<ActionResult> ControlPanel()
        {
            try
            {
                return View(await _UniversityStudentServicePrincipal.GetAllUniversityStudents());
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }   
        }
    }
}