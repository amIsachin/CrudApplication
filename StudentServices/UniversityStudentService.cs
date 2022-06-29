using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StudentServices
{
    public class UniversityStudentService : IUniversityStudentService
    {
        private string cs = ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString;

        public async Task<List<UniversityStudentEntity>> GetAllUniversityStudents()
        {
            List<UniversityStudentEntity> _universityStudentEntity = new List<UniversityStudentEntity>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllUniversityStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    UniversityStudentEntity universityStudentEntity = new UniversityStudentEntity();

                    universityStudentEntity.EnrolmentNumber =  Convert.ToInt32(dr.GetValue(0).ToString());
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

            return  _universityStudentEntity;
        }
    }
}
