using BusinessEntity;
using BusinessLogics;
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
        public List<StudentEntity> Search(string search, bool isTrue)
        {
            if (isTrue is true)
            {
                if (!string.IsNullOrWhiteSpace(search))
                {
                    return _StudentsService.GetAllStudents().Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
                }
                else
                {
                    return _StudentsService.GetAllStudents().ToList();
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(search))
                {
                    return _StudentsService.GetAllStudents().Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
                }
                else
                {
                    return _StudentsService.GetAllStudents().OrderByDescending(x => x.ID).Take(5).ToList();
                }
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

        /// <summary>
        /// This line of code return a single record using Roll Number.
        /// </summary>
        /// <param name="rollNumber"></param>
        /// <returns></returns>
        public StudentEntity GetStudentByRollNumber(int? rollNumber)
        {
            return _StudentsService.GetAllStudents().FirstOrDefault(x => x.RollNumber == rollNumber);
        }

        /// <summary>
        /// This line of code perform Create And Edit Operatoin.
        /// </summary>
        /// <param name="studentEntity"></param>
        /// <returns></returns>
        public bool PerformActions(StudentEntity studentEntity)
        {
            if (studentEntity.RollNumber > 0)
            {
                if (_StudentsService.UpdateStudent(studentEntity) is true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (studentEntity.RollNumber <= 0)
            {
                studentEntity.ID = CommonMethods.GenerateRandomNumber();

                if (_StudentsService.InsertStudent(studentEntity) is true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// This line code perform delete operation.
        /// </summary>
        /// <param name="rollNumber"></param>
        /// <returns></returns>
        public bool PerformDelete(int rollNumber)
        {
            if (_StudentsService.DeleteStudent(rollNumber) is true)
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