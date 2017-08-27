using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.Domain.Students
{
    public enum StudentLoginResults
    {
        Successful = 1,
        WrongPassword = 2,
        UserNotExist = 3,
    }
}
