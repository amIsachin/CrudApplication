using BusinessEntity;
using ServicePrincipals;
using StudentServices;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels;

namespace Crud.Web.Controllers
{
    public class UniversityController : Controller
    {
        #region InitializeDependencyInjectionInstance
        private readonly IUniversityStudentService _UniversityStudentService = null;
        private readonly UniversityStudentServicePrincipal _UniversityStudentServicePrincipal = null;
        private readonly CourseServicePrincipal _CourseServicePrincipal = null;
        public UniversityController(IUniversityStudentService universityStudentService, ICourseService courseService)
        {
            this._UniversityStudentService = universityStudentService;
            this._UniversityStudentServicePrincipal = new UniversityStudentServicePrincipal(universityStudentService);
            this._CourseServicePrincipal = new CourseServicePrincipal(courseService);
        }
        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Admission()
        {
            return View(await _CourseServicePrincipal.GetAllCourses());
        }

        [HttpPost]
        public async Task<ActionResult> Admission(UniversityStudentCombineCourseBindingViewModel universityStudentEntity)
        {
            //UniversityStudentCombineCourseBindingViewModel
            return View();
        }
    }
}