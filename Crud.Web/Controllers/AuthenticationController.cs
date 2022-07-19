using BusinessEntity;
using BusinessLogics;
using ServicePrincipals;
using StudentServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public partial class AuthenticationController : Controller
    {
        private readonly IAuthenticationServices _AuthenticationServices = null;
        AthenticationServicePrincipal _AthenticationServicePrincipal = null;
        public AuthenticationController(IAuthenticationServices authenticationServices)
        {
            this._AuthenticationServices = authenticationServices;
            this._AthenticationServicePrincipal = new AthenticationServicePrincipal(authenticationServices);
        }

        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(CreateAccountEntity createAccountEntity)
        {
            CommonMethods.IsAvailable(createAccountEntity.Email, createAccountEntity.Number);
            //await AthenticationServicePrincipal.Instance.InsertCourseEntity(createAccountEntity);
            await _AthenticationServicePrincipal.InsertCreateAccountEntity(createAccountEntity);
            return View();
        }

    }
}