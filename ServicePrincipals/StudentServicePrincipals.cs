using BusinessEntity;
using StudentServices;
using System.Collections.Generic;
using System.Linq;

namespace ServicePrincipals
{
    public sealed class StudentServicePrincipals
    {
        private readonly IStudentsService _StudentsService = null;
        public StudentServicePrincipals(IStudentsService studentsService)
        {
            _StudentsService = studentsService;
        }

        /// <summary>
        /// This method return Search result accourding to user search if
        /// search is null then return All Students.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<StudentEntity> Search(string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                return _StudentsService.GetAllStudents().Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            else
            {
                return _StudentsService.GetAllStudents().OrderBy(x => x.ID).Take(5).ToList();
            }
        }

        /// <summary>
        /// This line of code return all Student.
        /// </summary>
        /// <returns></returns>
        public List<StudentEntity> GetAllStudents()
        {
            return _StudentsService.GetAllStudents();
        }
    }
}