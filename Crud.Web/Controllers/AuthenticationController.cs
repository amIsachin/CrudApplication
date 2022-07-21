using BusinessEntity;
using ServicePrincipals;
using StudentServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Crud.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        #region InitializeDependencyInjection
        private readonly IAuthenticationServices _AuthenticationServices = null;
        AthenticationServicePrincipal _AthenticationServicePrincipal = null;
        public AuthenticationController(IAuthenticationServices authenticationServices)
        {
            this._AuthenticationServices = authenticationServices;
            this._AthenticationServicePrincipal = new AthenticationServicePrincipal(authenticationServices);
        }
        #endregion

        [HttpGet]
        public ActionResult CreateAccount() //signup
        {
            try
            {
                return View();
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(CreateAccountEntity createAccountEntity)
        {
            try
            {
                if (await _AthenticationServicePrincipal.InsertCreateAccountEntity(createAccountEntity))
                {
                    
                }
                return View();
            }
            catch (System.Exception)
            {
                //return new HttpStatusCodeResult(500);
                return View("Error");
            }
        }


        public ActionResult SignIn()
        {
            return View();
        }

    }
}