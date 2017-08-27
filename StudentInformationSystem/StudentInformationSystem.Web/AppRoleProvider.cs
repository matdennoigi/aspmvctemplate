using StudentInformationSystem.Core.Infrastructure;
using StudentInformationSystem.Services.Authentication;
using StudentInformationSystem.Services.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StudentInformationSystem.Web
{
    public class AppRoleProvider : RoleProvider
    {
        private Dictionary<string, string[]> rolesInUsers = 
            new Dictionary<string, string[]>();

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            
            var authenticationService = EngineContext.Current.Resolve<IAuthenticationService>();
            foreach (var username in usernames)
            {
                authenticationService.AddRolesToUser(username, roleNames);
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {

            var authenticationService = EngineContext.Current.Resolve<IAuthenticationService>();
            return authenticationService.GetRolesByUsername(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var roles = GetRolesForUser(username);
            return roles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}