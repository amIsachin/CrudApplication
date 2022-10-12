using BusinessEntity;
using StudentServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ViewModels;

namespace ServicePrincipals
{
    public class CourseServicePrincipal
    {
        private readonly ICourseService _CourseService = null;
        public CourseServicePrincipal(ICourseService courseService)
        {
            _CourseService = courseService;
        }

        /// <summary>
        /// Get All Courses functionality like pagination.
        /// </summary>
        /// <returns></returns>
        public async Task<CourseBindingViewModelPagination> GetAllCoursesPagination(string isClicked, int pageNo)
        {
            int pageSize = 2;
            CourseBindingViewModelPagination courseBindingViewModelList = new CourseBindingViewModelPagination();
            courseBindingViewModelList.Course = await _CourseService.GetAllCourses();

            if (!string.IsNullOrWhiteSpace(isClicked) && pageNo > 0)
            {
                pageSize = pageNo > 0 ? pageSize * pageSize - 1 : pageSize;
                courseBindingViewModelList.Course = courseBindingViewModelList.Course.OrderByDescending(x => x.ID)
                    .Take(pageSize).ToList();
            }
            else
            {
                courseBindingViewModelList.Course = courseBindingViewModelList.Course.OrderByDescending(x => x.ID)
                    .Take(pageSize).ToList();
            }

            //courseBindingViewModelList.Course = courseBindingViewModelList.Course.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            //courseBindingViewModelList.Course = courseBindingViewModelList.Course.Take(pageSize).ToList();

            return courseBindingViewModelList;

        }

        /// <summary>
        /// Get All Courses functionality.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CourseEntity>> GetAllCourses()
        {
            return (await _CourseService.GetAllCourses());

            //var uniqueOrders = orders.Select(x => new { x.location, x.amount }).Distinct();

            //return (await _CourseService.GetAllCourses())
            //    .Distinct(new CourseEntityComparer()).ToList();

            //var uniqueOrders = orders.GroupBy(x => new { x.location }).Select(x => x);

            //return (await _CourseService.GetAllCourses()).GroupBy(x => new { x.ID, x.Name, x.StudentID, x.CreatedOn })
            //    .Distinct(new CourseEntityComparer()).ToList();

            //return (await _CourseService.GetAllCourses()).Select(x => new CourseEntity { x.ID, x.Name, x.StudentID, x.CreatedOn }).GroupBy(x => x.Name).ToList();


        }

        /// <summary>
        /// Get distinct course name functionality.
        /// this method is not used right now.
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetDistinctCourseName()
        {
            return (await _CourseService.GetDisnctCourseName()).Distinct().ToList();
        }

        /// <summary>
        /// Get Course By ID functionality.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<CourseEntity> GetCourseById(int ID)
        {
            return await _CourseService.GetCourseById(ID);
        }
    }
}
