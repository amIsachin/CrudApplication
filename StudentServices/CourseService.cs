using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StudentServices
{
    public class CourseService : ICourseService
    {
        //private readonly string cs = ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString;

        /// <summary>
        /// Get All Courses functionality.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CourseEntity>> GetAllCourses()
        {
            List<CourseEntity> _courseEntity = new List<CourseEntity>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCourses", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    CourseEntity courseEntity = new CourseEntity();
                    courseEntity.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                    courseEntity.Name = dr.GetValue(1).ToString();
                    courseEntity.CreatedOn = Convert.ToDateTime(dr.GetValue(2).ToString());
                    courseEntity.StudentID = Convert.ToInt32(dr.GetValue(3).ToString());

                    _courseEntity.Add(courseEntity);
                }
            }

            return _courseEntity;
        }

        /// <summary>
        /// Get course by ID functionality.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<CourseEntity> GetCourseById(int ID)
        {
            CourseEntity _courseEntity = new CourseEntity();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetCourseByID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (await dr.ReadAsync())
                {
                    _courseEntity.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                    _courseEntity.Name = dr.GetValue(1).ToString();
                    _courseEntity.CreatedOn = Convert.ToDateTime(dr.GetValue(2).ToString());
                    _courseEntity.StudentID = Convert.ToInt32(dr.GetValue(3).ToString());
                }
            }

            return _courseEntity;
        }
    }
}
