using StudentInformationSystem.Core.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services.Students
{
    public interface IStudentService
    {
        Student GetStudentByUsername(string username);
       
    }
}
