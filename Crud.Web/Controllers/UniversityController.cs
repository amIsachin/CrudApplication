using ServicePrincipals;
using StudentServices;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class UniversityController : Controller
    {
        #region InitializeDependencyInjectionInstance
        private readonly IUniversityStudentService _UniversityStudentService = null;
        private readonly UniversityStudentServicePrincipal _UniversityStudentServicePrincipal = null;
        public UniversityController(IUniversityStudentService universityStudentService)
        {
            this._UniversityStudentService = universityStudentService;
            this._UniversityStudentServicePrincipal = new UniversityStudentServicePrincipal(universityStudentService);
        }
        #endregion


        public ActionResult Index()
        {
            return View();
        }
    }
}