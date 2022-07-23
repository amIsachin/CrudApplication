using BusinessEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentServices
{
    public interface IAuthenticationServices
    {
        Task<bool> InsertCreateAccountEntity(CreateAccountEntity createAccountEntity);
        Task<List<CreateAccountEntity>> GetAllCreateAccounts();
    }
}
