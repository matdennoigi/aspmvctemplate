using StudentInformationSystem.Core.Domain.Membership;
using StudentInformationSystem.Core.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services.Authentication
{
    public interface IAuthenticationService
    {
        void SignIn(Student student, bool createPersistentCookie);

        void SingOut();

        void AddRolesToUser(string username, string[] roleNames);

        Role GetRoleByName(string roleName);

        string[] GetRolesByUsername(string username);
    }
}
