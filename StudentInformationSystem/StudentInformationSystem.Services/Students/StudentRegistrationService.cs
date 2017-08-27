using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Core.Domain.Students;
using StudentInformationSystem.Services.Security;

namespace StudentInformationSystem.Services.Students
{
    public class StudentRegistrationService : IStudentRegistrationService
    {
        #region Fields

        private IStudentService studentService;
        private IEncryptionService encryptionService;

        #endregion

        #region Ctor

        public StudentRegistrationService(IStudentService studentService,
            IEncryptionService encryptionService)
        {
            this.studentService = studentService;
            this.encryptionService = encryptionService;
        }

        #endregion

        #region Method
        public StudentLoginResults ValidateStudent(string username, string password)
        {
            var student = studentService.GetStudentByUsername(username);

            if (student == null)
                return StudentLoginResults.UserNotExist;

            if (!PasswordMatch(student.Password, password))
                return StudentLoginResults.WrongPassword;

            return StudentLoginResults.Successful;
        }

        protected bool PasswordMatch(string modelPassword, string enteredPassword)
        {
            string hashedEnterPassword = encryptionService.CreateHashPassword(enteredPassword);
            return hashedEnterPassword.Equals(modelPassword, StringComparison.CurrentCultureIgnoreCase);
        }
        #endregion
    }
}
