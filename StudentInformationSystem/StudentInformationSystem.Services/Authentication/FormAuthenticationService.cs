using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Core.Domain.Students;
using System.Web.Security;
using System.Web;
using StudentInformationSystem.Core.Data;
using StudentInformationSystem.Core.Domain.Membership;
using StudentInformationSystem.Services.Students;

namespace StudentInformationSystem.Services.Authentication
{
    public class FormAuthenticationService : IAuthenticationService
    {
        #region Fields

        private HttpContextBase httpContext;
        private TimeSpan expirationTimespan;
        private IStudentService studentService;
        private IRepository<Student> studentRepository;
        private IRepository<Role> roleRepository;
        private IRepository<UserInRole> userInRoleRepository;

        #endregion

        #region Ctor

        public FormAuthenticationService(HttpContextBase httpContext,
            IStudentService studentService,
            IRepository<Student> studentRepository,
            IRepository<Role> roleRepository,
            IRepository<UserInRole> userInRoleRepository)
        {
            this.httpContext = httpContext;
            this.expirationTimespan = FormsAuthentication.Timeout;
            this.studentService = studentService;
            this.studentRepository = studentRepository;
            this.roleRepository = roleRepository;
            this.userInRoleRepository = userInRoleRepository;
        }

        #endregion

        #region SignIn / SignOut

        public void SignIn(Student student, bool createPersistentCookie)
        {
            var now = DateTime.Now;

            var ticket = new FormsAuthenticationTicket(
                1,
                student.Username,
                now,
                now.Add(expirationTimespan),
                createPersistentCookie,
                student.Username,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Path = FormsAuthentication.FormsCookiePath;
            Roles.AddUserToRoles(student.Username, new string[] { "reader", "admin" });
            httpContext.Response.Cookies.Add(cookie);
        }

        public void SingOut()
        {
            FormsAuthentication.SignOut();
        }

        #endregion

        #region Role Management

        public void AddRolesToUser(string username, string[] roleNames)
        {
            var student = studentService.GetStudentByUsername(username);
            if (student == null)
                return;

            var userInRoles = new List<UserInRole>();
            var roles = GetRolesByNames(roleNames);
            foreach (var role in roles)
            {
                userInRoles.Add(new UserInRole { RoleId = role.Id, StudentId = student.Id, GrantOnUtc = DateTime.Now });
            }
            userInRoleRepository.Insert(userInRoles);
        }

        public Role GetRoleByName(string roleName)
        {
            var query = from role in roleRepository.Table
                        where role.RoleName.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)
                        select role;

            Role result = query.FirstOrDefault();
            return result;
        }

        public Role[] GetRolesByNames(string[] roleNames)
        {
            var query = from role in roleRepository.Table
                        where roleNames.Contains(role.RoleName)
                        select role;

            List<Role> roles = new List<Role>();
            foreach (var role in query)
            {
                roles.Add(role);
            }

            return roles.ToArray();
        }

        public string[] GetRolesByUsername(string username)
        {
            var query = from student in studentRepository.Table
                        join userInRole in userInRoleRepository.Table on student.Id equals userInRole.StudentId
                        join role in roleRepository.Table on userInRole.RoleId equals role.Id
                        select role;

            List<string> roles = new List<string>();
            foreach (var role in query)
            {
                roles.Add(role.RoleName);
            }

            return roles.ToArray();
        }

        #endregion
    }
}
