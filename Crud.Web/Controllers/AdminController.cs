using ServicePrincipals;
using StudentServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
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
        public async Task<ActionResult> ControlPanel()
        {
            return View(await _UniversityStudentServicePrincipal.GetAllUniversityStudents());
        }
    }
}