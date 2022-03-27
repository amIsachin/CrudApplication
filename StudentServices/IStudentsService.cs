using BusinessEntity;
using System.Collections.Generic;

namespace StudentServices
{
    public interface IStudentsService
    {
        List<StudentEntity> GetAllStudents();
        bool InsertStudent(StudentEntity studentEntity);
    }
}
