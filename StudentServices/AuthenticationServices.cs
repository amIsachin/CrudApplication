using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ViewModels;

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

        public List<InnerJoinUserRoleWithCreateAccountEntity> GetAllInnerJoinUserRoleWithCreateAccountEntity()
        {
            List<InnerJoinUserRoleWithCreateAccountEntity> _innerJoinUserRoleWithCreateAccountEntity = new List<InnerJoinUserRoleWithCreateAccountEntity>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("InnerJoinUserRoleWithCreateAccount", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InnerJoinUserRoleWithCreateAccountEntity innerJoinUserRoleWithCreateAccountEntity = new InnerJoinUserRoleWithCreateAccountEntity();
                    innerJoinUserRoleWithCreateAccountEntity.UserRoleID = Convert.ToInt32(dr.GetValue(0).ToString());
                    innerJoinUserRoleWithCreateAccountEntity.Role = dr.GetValue(1).ToString();
                    innerJoinUserRoleWithCreateAccountEntity.UserID = Convert.ToInt32(dr.GetValue(2).ToString());
                    innerJoinUserRoleWithCreateAccountEntity.UserRoleCreatedOn = Convert.ToDateTime(dr.GetValue(3).ToString());
                    innerJoinUserRoleWithCreateAccountEntity.CreatedAccountID = Convert.ToInt32(dr.GetValue(4).ToString());
                    innerJoinUserRoleWithCreateAccountEntity.UserName = dr.GetValue(5).ToString();
                    innerJoinUserRoleWithCreateAccountEntity.Email = dr.GetValue(6).ToString();
                    innerJoinUserRoleWithCreateAccountEntity.Number = dr.GetValue(7).ToString();
                    innerJoinUserRoleWithCreateAccountEntity.Password= dr.GetValue(8).ToString();
                    innerJoinUserRoleWithCreateAccountEntity.ConfirmPassword = dr.GetValue(9).ToString();
                    innerJoinUserRoleWithCreateAccountEntity.CreateAccountCreatedOn = Convert.ToDateTime(dr.GetValue(10).ToString());

                    _innerJoinUserRoleWithCreateAccountEntity.Add(innerJoinUserRoleWithCreateAccountEntity);
                }
            }

            return _innerJoinUserRoleWithCreateAccountEntity;
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
