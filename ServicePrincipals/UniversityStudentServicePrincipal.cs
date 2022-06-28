using StudentServices;

namespace ServicePrincipals
{
    public class UniversityStudentServicePrincipal
    {
        private readonly IUniversityStudentService _UniversityStudentService = null;
        public UniversityStudentServicePrincipal(IUniversityStudentService universityStudentService)
        {
            this._UniversityStudentService = universityStudentService;
        }
    }
}
