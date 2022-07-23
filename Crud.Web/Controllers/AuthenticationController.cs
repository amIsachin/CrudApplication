using BusinessEntity;
using ServicePrincipals;
using StudentServices;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

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
        public async Task<ActionResult> CreateAccount(CreateAccountEntity createAccountEntity) //signup
        {
            try
            {
                if (await _AthenticationServicePrincipal.InsertCreateAccountEntity(createAccountEntity))
                {
                    return RedirectToAction("ControlPanel", "Admin");
                }
                else
                {
                    return View();
                }
            }
            catch (System.Exception)
            {
                //return new HttpStatusCodeResult(500);
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(CreateAccountEntity createAccountEntity)
        {
            if (await _AthenticationServicePrincipal.IsExistAccount(createAccountEntity.Email, createAccountEntity.Password))
            {
                FormsAuthentication.SetAuthCookie(createAccountEntity.UserName, false);
                return RedirectToAction("ControlPanel", "Admin", createAccountEntity.UserName);
            }
            else
            {
                return View();
            }
        }

    }
}