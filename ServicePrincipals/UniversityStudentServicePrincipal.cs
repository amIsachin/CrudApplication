using BusinessEntity;
using StudentServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace ServicePrincipals
{
    public sealed class UniversityStudentServicePrincipal
    {
        private readonly IUniversityStudentService _UniversityStudentService = null;
        public UniversityStudentServicePrincipal(IUniversityStudentService universityStudentService)
        {
            this._UniversityStudentService = universityStudentService;
        }

        /// <summary>
        /// Here return all University students functionality.
        /// </summary>
        /// <returns></returns>
        public async Task<List<UniversityStudentEntity>> GetAllUniversityStudents()
        {
            return await _UniversityStudentService.GetAllUniversityStudents();
        }

        /// <summary>
        /// Save University student with course functionality.
        /// </summary>
        /// <param name="universityStudentCombineCourseBindingViewModel"></param>
        /// <returns></returns>
        public async Task<bool> InsertUniversituStudentCombineCourse(UniversityStudentCombineCourseBindingViewModel universityStudentCombineCourseBindingViewModel)
        {
            if (await _UniversityStudentService.InsertUniversituStudentCombineCourse(universityStudentCombineCourseBindingViewModel) is true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}