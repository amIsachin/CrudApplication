using BusinessEntity;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace StudentServices
{
    public interface IUniversityStudentService
    {
        Task<List<UniversityStudentEntity>> GetAllUniversityStudents();
        Task<bool> InsertUniversituStudentCombineCourse(UniversityStudentCombineCourseBindingViewModel universityStudentCombineCourseBindingViewModel);
    }
}
