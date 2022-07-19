using BusinessEntity;
using System.Threading.Tasks;

namespace StudentServices
{
    public interface IAuthenticationServices
    {
        Task<bool> InsertCreateAccountEntity(CreateAccountEntity createAccountEntity);
    }
}
