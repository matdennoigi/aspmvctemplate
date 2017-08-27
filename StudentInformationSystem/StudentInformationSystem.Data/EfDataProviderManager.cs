using StudentInformationSystem.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Data
{
    public class EfDataProviderManager : BaseDataProviderManager
    {
        public EfDataProviderManager(DataSettings dataSettings) : base(dataSettings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {
            string providerName = Settings.DataProviderName;
            switch (providerName)
            {
                case "System.Data.SqlClient":
                    return new SqlServerDataProvider();
            }
            return null;
        }
    }
}
