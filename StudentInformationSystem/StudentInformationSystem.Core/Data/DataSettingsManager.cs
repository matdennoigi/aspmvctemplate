using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.Data
{
    public partial class DataSettingsManager
    {

        public DataSettings LoadSettings()
        {
            var appDataConnectionString = ConfigurationManager.ConnectionStrings["AppDbConnection"].ConnectionString;
            var appDataProviderName = ConfigurationManager.ConnectionStrings["AppDbConnection"].ProviderName;
            return new DataSettings
            {
                DataConnectionString = appDataConnectionString,
                DataProviderName = appDataProviderName
            };
        }
    }
}
