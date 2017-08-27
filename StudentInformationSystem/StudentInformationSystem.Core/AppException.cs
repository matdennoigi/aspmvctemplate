using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core
{
    [Serializable]
    public class AppException : Exception
    {
        public AppException()
        {
        }

        public AppException(string message) 
            : base(message)
        {
        }

        public AppException(string messageFormat, params object[] parameters) 
            : base(string.Format(messageFormat, parameters))
        {

        }
    }
}
