using BusinessEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentServices
{
    public interface ICourseService
    {
        Task<List<CourseEntity>> GetAllCourses();
    }
}
