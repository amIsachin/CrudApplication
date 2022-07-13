using BusinessEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentServices
{
    public interface ICourseService
    {
        Task<List<CourseEntity>> GetAllCourses();
        Task<CourseEntity> GetCourseById(int ID);
        Task<List<string>> GetDisnctCourseName();
    }
}
