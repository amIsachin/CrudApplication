using BusinessEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentServices
{
    public interface IUniversityStudentService
    {
       Task<List<UniversityStudentEntity>> GetAllUniversityStudents();
    }
}
