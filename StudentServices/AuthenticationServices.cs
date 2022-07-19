using BusinessEntity;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StudentServices
{
    public class AuthenticationServices : IAuthenticationServices
    {
        public async Task<bool> InsertCreateAccountEntity(CreateAccountEntity createAccountEntity)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Crud-app"].ConnectionString))
            {
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
        }
    }
}
