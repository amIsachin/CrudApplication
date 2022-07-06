using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ViewModels;

namespace StudentServices
{
    public class UniversityStudentService : IUniversityStudentService
    {
        private readonly string cs = ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString;

        /// <summary>
        /// Get All University student functionality.
        /// </summary>
        /// <returns></returns>
        public async Task<List<UniversityStudentEntity>> GetAllUniversityStudents()
        {
            List<UniversityStudentEntity> _universityStudentEntity = new List<UniversityStudentEntity>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllUniversityStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    UniversityStudentEntity universityStudentEntity = new UniversityStudentEntity();

                    universityStudentEntity.EnrolmentNumber = Convert.ToInt32(dr.GetValue(0).ToString());
                    universityStudentEntity.Name = dr.GetValue(1).ToString();
                    universityStudentEntity.Age = Convert.ToInt32(dr.GetValue(2).ToString());
                    universityStudentEntity.Gender = dr.GetValue(3).ToString();
                    universityStudentEntity.Fees = Convert.ToInt32(dr.GetValue(4).ToString());
                    universityStudentEntity.City = dr.GetValue(5).ToString();
                    universityStudentEntity.Document = dr.GetValue(6).ToString();
                    universityStudentEntity.Image = dr.GetValue(7).ToString();
                    universityStudentEntity.CreatedOn = Convert.ToDateTime(dr.GetValue(8).ToString());

                    _universityStudentEntity.Add(universityStudentEntity);
                }

            }

            return _universityStudentEntity;
        }

        /// <summary>
        /// Insert university student with course.
        /// </summary>
        /// <param name="universityStudentCombineCourseBindingViewModel"></param>
        /// <returns></returns>
        public async Task<bool> InsertUniversituStudentCombineCourse(UniversityStudentCombineCourseBindingViewModel universityStudentCombineCourseBindingViewModel)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertUniversityStudentCombineCourse", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", universityStudentCombineCourseBindingViewModel.Name);
                cmd.Parameters.AddWithValue("@Age", universityStudentCombineCourseBindingViewModel.Age);
                cmd.Parameters.AddWithValue("@Gender", universityStudentCombineCourseBindingViewModel.Gender);
                cmd.Parameters.AddWithValue("@Fees", universityStudentCombineCourseBindingViewModel.Fees);
                cmd.Parameters.AddWithValue("@City", universityStudentCombineCourseBindingViewModel.City);
                cmd.Parameters.AddWithValue("@Document", universityStudentCombineCourseBindingViewModel.Document);
                cmd.Parameters.AddWithValue("@Image", universityStudentCombineCourseBindingViewModel.Image);
                cmd.Parameters.AddWithValue("@CreaedOn", universityStudentCombineCourseBindingViewModel.CreatedOn);

                cmd.Parameters.AddWithValue("@CourseName", universityStudentCombineCourseBindingViewModel.CourseName);
                cmd.Parameters.AddWithValue("@CreatedOn", universityStudentCombineCourseBindingViewModel.CreatedOn);

                con.Open();
                int isInserted = await cmd.ExecuteNonQueryAsync();

                if (isInserted > 0)
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
}
