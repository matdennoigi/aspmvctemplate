using StudentInformationSystem.Core;
using StudentInformationSystem.Core.Data;
using StudentInformationSystem.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Data
{
    public class EfStartupTask : IStartupTask
    {
        public int Order
        {
            get { return -10000; }
        }

        public void Execute()
        {
            var settings = EngineContext.Current.Resolve<DataSettings>();
            if (settings != null && settings.IsValid())
            {
                var dataProvider = EngineContext.Current.Resolve<IDataProvider>();
                if (dataProvider == null)
                    throw new AppException("No IDataProvider found");

                dataProvider.SetDatabaseInitializer();
            }
        }
    }
}
