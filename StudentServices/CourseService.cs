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
        private readonly string cs = ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString;

        /// <summary>
        /// Get All Courses functionality.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CourseEntity>> GetAllCourses()
        {
            List<CourseEntity> _courseEntity = new List<CourseEntity>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCourses", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CourseEntity courseEntity = new CourseEntity();
                    courseEntity.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                    courseEntity.Name = dr.GetValue(1).ToString();
                    courseEntity.CreatedOn = Convert.ToDateTime( dr.GetValue(2).ToString());
                    courseEntity.StudentID = Convert.ToInt32(dr.GetValue(3).ToString());

                    _courseEntity.Add(courseEntity);
                }
            }

            return _courseEntity;
        }
    }
}
