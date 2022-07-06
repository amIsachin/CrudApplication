using BusinessEntity;
using StudentServices;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// Get All Courses functionality.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CourseEntity>> GetAllCourses()
        {
            return await _CourseService.GetAllCourses();
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
