using StudentServices;
using ViewModels;
using System.Web.Security;
using System.Collections.Generic;

namespace AuthRoles
{
    public class WebRoleProviders : RoleProvider
    {
        private readonly IAuthenticationServices _authenticationServices;
        public WebRoleProviders(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;
        }

        public override string ApplicationName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var record = await _authenticationServices.GetAllInnerJoinUserRoleWithCreateAccountEntity();
            //throw new System.NotImplementedException();
            return new List<string>() { "Sacin" };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }
    }
}
