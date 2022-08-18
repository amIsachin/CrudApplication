using BusinessEntity;
using StudentServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ViewModels;

namespace ServicePrincipals
{
    public class AthenticationServicePrincipal
    {
        #region Sigleton
        public static AthenticationServicePrincipal Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AthenticationServicePrincipal();
                }

                return instance;
            }
        }
        private static AthenticationServicePrincipal instance { get; set; }

        private AthenticationServicePrincipal()
        {
        }
        #endregion


        #region InitializeDependencyInjection
        private readonly IAuthenticationServices _authenticationServices;
        public AthenticationServicePrincipal(IAuthenticationServices authenticationServices)
        {
            this._authenticationServices = authenticationServices;
        }
        #endregion

        /// <summary>
        /// Insert Craete Account functinality.
        /// </summary>
        /// <param name="createAccountEntity"></param>
        /// <returns></returns>
        public async Task<bool> InsertCreateAccountEntity(CreateAccountEntity createAccountEntity)
        {
            try
            {
                if (await _authenticationServices.InsertCreateAccountEntity(createAccountEntity) is true)
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

        public async Task<List<CreateAccountEntity>> GetAllCreateAccounts()
        {
            return await _authenticationServices.GetAllCreateAccounts();
        }

        public async Task<bool> IsExistAccount(string email, string password)
        {
            try
            {
                if ((await _authenticationServices.GetAllCreateAccounts()).Any(x => x.Email == email && x.Password == password))
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

        //public async Task<List<InnerJoinUserRoleWithCreateAccountEntity>> GetAllInnerJoinUserRoleWithCreateAccountEntity()
        //{
        //    return await _authenticationServices.GetAllInnerJoinUserRoleWithCreateAccountEntity();
        //}

        public string[] GetAllInnerJoinUserRoleWithCreateAccountEntityWithParam(string userName)
        {
            return _authenticationServices.GetAllInnerJoinUserRoleWithCreateAccountEntity()
                .Where(x => x.Role == userName).Select(x => x.Role).ToArray();
        }


    }
}