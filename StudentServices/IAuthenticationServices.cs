using BusinessEntity;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace StudentServices
{
    public interface IAuthenticationServices
    {
        Task<bool> InsertCreateAccountEntity(CreateAccountEntity createAccountEntity);
        Task<List<CreateAccountEntity>> GetAllCreateAccounts();
        List<InnerJoinUserRoleWithCreateAccountEntity> GetAllInnerJoinUserRoleWithCreateAccountEntity();
    }
}
