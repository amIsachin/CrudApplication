using StudentServices;
using System.Web.Security;
using ServicePrincipals;

//namespace AuthRoles
//{
//    public class WebRoleProviders : RoleProvider
//    {
//        private readonly IAuthenticationServices _authenticationServices;
//        private readonly AthenticationServicePrincipal _athenticationServicePrincipal;
//        public WebRoleProviders(IAuthenticationServices authenticationServices)
//        {
//            this._authenticationServices = authenticationServices;
//            this._athenticationServicePrincipal = new AthenticationServicePrincipal(authenticationServices);

//        }

//        public override string ApplicationName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

//        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override void CreateRole(string roleName)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override string[] GetAllRoles()
//        {
//            throw new System.NotImplementedException();
//        }

//        public override string[] GetRolesForUser(string username)
//        {
//            return _athenticationServicePrincipal.GetAllInnerJoinUserRoleWithCreateAccountEntityWithParam(username);
//            //throw new System.NotImplementedException();
//            //return new List<string>() { "Sacin" };
//        }

//        public override string[] GetUsersInRole(string roleName)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override bool IsUserInRole(string username, string roleName)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
//        {
//            throw new System.NotImplementedException();
//        }

//        public override bool RoleExists(string roleName)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}