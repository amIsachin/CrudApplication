using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentServices
{
    public sealed class StudentsService : IStudentsService
    {
        #region ConnectionString
        //--> Connection String
        private readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString);
        #endregion

        /// <summary>
        /// Get all student functionality.
        /// </summary>
        /// <returns></returns>
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
                }
                con.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return studentList;
        }

        /// <summary>
        /// Insert student functionality.
        /// </summary>
        /// <param name="studentEntity"></param>
        /// <returns></returns>
        public bool InsertStudent(StudentEntity studentEntity)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Insert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", studentEntity.ID);
                cmd.Parameters.AddWithValue("@createdOn", studentEntity.CreatedOn);
                cmd.Parameters.AddWithValue("@name", studentEntity.Name);
                cmd.Parameters.AddWithValue("@class", studentEntity.Class);
                cmd.Parameters.AddWithValue("@gender", studentEntity.Gender);
                cmd.Parameters.AddWithValue("@age", studentEntity.Age);
                cmd.Parameters.AddWithValue("@fees", studentEntity.Fees);
                cmd.Parameters.AddWithValue("@city", studentEntity.City);
                cmd.Parameters.AddWithValue("@address", studentEntity.Address);
                cmd.Parameters.AddWithValue("@admissionSession", studentEntity.AdmissionSession);

                con.Open();
                int isTrue = cmd.ExecuteNonQuery();
                con.Close();

                if (isTrue > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

    }
}