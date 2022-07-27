using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StudentServices
{
    public class AuthenticationServices : IAuthenticationServices
    {
        public async Task<List<CreateAccountEntity>> GetAllCreateAccounts()
        {
            try
            {
                List<CreateAccountEntity> _createAccountEntity = new List<CreateAccountEntity>();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllCreateAccount", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = await cmd.ExecuteReaderAsync();
                    while (await dr.ReadAsync())
                    {
                        CreateAccountEntity createAccountEntity = new CreateAccountEntity();

                        createAccountEntity.ID = Convert.ToInt32(dr.GetValue(0).ToString());
                        createAccountEntity.UserName = dr.GetValue(1).ToString();
                        createAccountEntity.Email = dr.GetValue(2).ToString();
                        createAccountEntity.Number = dr.GetValue(3).ToString();
                        createAccountEntity.Password = dr.GetValue(4).ToString();
                        createAccountEntity.ConfirmPassword = dr.GetValue(5).ToString();
                        createAccountEntity.CreatedOn = Convert.ToDateTime(dr.GetValue(6).ToString());

                        _createAccountEntity.Add(createAccountEntity);

                    }
                }

                return _createAccountEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InsertCreateAccountEntity(CreateAccountEntity createAccountEntity)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString))
            {
                try
                {
                    createAccountEntity.Number = createAccountEntity.Number == null ? "" : createAccountEntity.Number;
                    createAccountEntity.Email = createAccountEntity.Email == null ? "" : createAccountEntity.Email;
                    SqlCommand cmd = new SqlCommand("spInsertCreateAccount", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", createAccountEntity.UserName);
                    cmd.Parameters.AddWithValue("@Email", createAccountEntity.Email);
                    cmd.Parameters.AddWithValue("@Number", createAccountEntity.Number);
                    cmd.Parameters.AddWithValue("@Password", createAccountEntity.Password);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", createAccountEntity.ConfirmPassword);
                    cmd.Parameters.AddWithValue("@CreatedOn", createAccountEntity.CreatedOn);

                    con.Open();

                    if (await cmd.ExecuteNonQueryAsync() > 0)
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
            }
        }


    }
}
