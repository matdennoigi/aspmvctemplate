using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.Data
{
    public class DataSettings
    {
        public string DataConnectionString
        {
            set;
            get;
        }

        public string DataProviderName
        {
            set;
            get;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(DataConnectionString) && !string.IsNullOrEmpty(DataProviderName);
        }
    }
}
