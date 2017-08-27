using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Core.Domain.Students;
using StudentInformationSystem.Core.Data;
using StudentInformationSystem.Core.Domain.Membership;

namespace StudentInformationSystem.Services.Students
{
    public class StudentService : IStudentService
    {
        #region Fields

        private IRepository<Student> studentRepository;

        #endregion

        #region Ctor

        public StudentService(IRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        #endregion

        public Student GetStudentByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            var query = from s in studentRepository.Table
                          orderby s.Id
                          where s.Username.Equals(username)
                          select s;

            var student = query.FirstOrDefault();

            return student;
        }
    }
}
