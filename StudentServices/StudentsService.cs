using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentServices
{
    public class StudentsService : IStudentsService
    {
        #region ConnectionString
        //--> Connection String
        private readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString);
        #endregion

        public List<StudentEntity> GetAllStudents()
        {
            List<StudentEntity> studentList = new List<StudentEntity>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Select", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    StudentEntity student = new StudentEntity();
                    student.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                    student.CreatedOn = Convert.ToDateTime(dr.GetValue(1).ToString());
                    student.RollNumber = Convert.ToInt32(dr.GetValue(2).ToString());
                    student.Name = dr.GetValue(3).ToString();
                    student.Class = dr.GetValue(4).ToString();
                    student.Gender = dr.GetValue(5).ToString();
                    student.Age = Convert.ToInt32(dr.GetValue(6).ToString());
                    student.Fees = Convert.ToInt32(dr.GetValue(7).ToString());
                    student.City = dr.GetValue(8).ToString();
                    student.Address = dr.GetValue(9).ToString();
                    student.AdmissionSession = Convert.ToDateTime(dr.GetValue(10).ToString());

                    studentList.Add(student);

                    //studentList.Add(new StudentEntity
                    //{
                    //    ID = Convert.ToInt32(dr.GetValue(0).ToString()),
                    //    CreatedOn = Convert.ToDateTime(dr.GetValue(1).ToString()),
                    //    RollNumber = Convert.ToInt32(dr.GetValue(1).ToString()),
                    //    Name = dr.GetValue(2).ToString(),
                    //    Class = dr.GetValue(3).ToString(),
                    //    Gender = dr.GetValue(4).ToString(),
                    //    Age = Convert.ToInt32(dr.GetValue(5).ToString()),
                    //    Fees = Convert.ToInt32(dr.GetValue(6).ToString()),
                    //    City = dr.GetValue(7).ToString(),
                    //    Address = dr.GetValue(8).ToString(),
                    //    AdmissionSession = Convert.ToDateTime(dr.GetValue(9).ToString())
                    //});
                }
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return studentList;
        }
    }
}