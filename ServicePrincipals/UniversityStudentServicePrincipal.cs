using BusinessEntity;
using StudentServices;
using System.Collections.Generic;
using System.Threading.Tasks;

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


    }
}