using BusinessEntity;
using DotNetOpenAuth.OpenId.Provider;
using Microsoft.Web.WebPages.OAuth;
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
                if (await _AthenticationServicePrincipal.InsertCreateAccountEntity(createAccountEntity) is true)
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
            try
            {
                if (await _AthenticationServicePrincipal.IsExistAccount(createAccountEntity.Email, createAccountEntity.Password))
                {
                    FormsAuthentication.SetAuthCookie("Sachin", false);
                    return RedirectToAction("ControlPanel", "Admin");
                }
                else
                {
                    return View();
                }
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("SignIn");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Facebook(string provider = "facebook")
        {
            OAuthWebSecurity.RequestAuthentication(provider, Url.Action("Returnback"));
            return RedirectToAction("ControlPanel", "Admin");
        }

        public ActionResult Returnback(string provider)
        {
            var result = OAuthWebSecurity.VerifyAuthentication();

            return RedirectToAction("ControlPanel", "Admin");
        }

        public ActionResult Google(string provider = "Google")
        {
            //IAuthenticationRequest request = openID.CreateRequest(openid_identifier);
            OAuthWebSecurity.RequestAuthentication(provider, Url.Action("GoogleRetrun"));

            return RedirectToAction("ControlPanel", "Admin");
        }
        public ActionResult GoogleRetrun(string provider)
        {
            OAuthWebSecurity.RequestAuthentication(provider, Url.Action("GoogleRetrun"));
            FormsAuthentication.SignOut();
            return RedirectToAction("ControlPanel", "Admin");
        }
    }
}