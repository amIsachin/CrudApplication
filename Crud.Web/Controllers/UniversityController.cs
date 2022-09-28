using BusinessLogics;
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
        public async Task<ActionResult> Admission()
        {
            try
            {
                UniversityStudentCombineCourseBindingViewModel UniversityStudentCombineCourseBindingViewModel = new
                    UniversityStudentCombineCourseBindingViewModel();
                UniversityStudentCombineCourseBindingViewModel.CourseList = await _CourseServicePrincipal.GetAllCourses();
                return View(UniversityStudentCombineCourseBindingViewModel);
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }

        }

        [HttpPost]
        public async Task<ActionResult> Admission(UniversityStudentCombineCourseBindingViewModel universityStudentCombineCourseBindingViewModel)
        {
            try
            {
                if (CommonMethods.SuspendCurrentExecutionEnvironment(universityStudentCombineCourseBindingViewModel.CourseID)
                        && CommonMethods.IsGenderValid(universityStudentCombineCourseBindingViewModel.Gender))
                {
                    var CourseRecord = await _CourseServicePrincipal.GetCourseById(universityStudentCombineCourseBindingViewModel.CourseID);
                    universityStudentCombineCourseBindingViewModel.CourseName = CourseRecord.Name;
                    universityStudentCombineCourseBindingViewModel.CreatedOn = CourseRecord.CreatedOn;

                    if (await _UniversityStudentServicePrincipal.InsertUniversituStudentCombineCourse(universityStudentCombineCourseBindingViewModel) is true)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        universityStudentCombineCourseBindingViewModel.CourseList = await _CourseServicePrincipal.GetAllCourses();
                        return View(universityStudentCombineCourseBindingViewModel);
                    }
                }
                else
                {
                    universityStudentCombineCourseBindingViewModel.CourseList = await _CourseServicePrincipal.GetAllCourses();
                    return View(universityStudentCombineCourseBindingViewModel);
                }
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ContactUs() 
        {
            return View();
        }

        public ActionResult Congratulation()
        {
            return View();
        }
    }
}