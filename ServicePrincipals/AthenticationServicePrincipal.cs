using StudentServices;

namespace ServicePrincipals
{
    public class AthenticationServicePrincipal
    {
        private readonly IAuthenticationServices _AuthenticationServices = null;
        public AthenticationServicePrincipal(IAuthenticationServices authenticationServices)
        {
            this._AuthenticationServices = authenticationServices;
        }
    }
}
