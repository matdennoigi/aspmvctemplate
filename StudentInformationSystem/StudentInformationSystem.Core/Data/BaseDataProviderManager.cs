using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.Data
{
    public abstract class BaseDataProviderManager
    {
        public BaseDataProviderManager(DataSettings dataSettings)
        {
            this.Settings = dataSettings;
        }

        protected DataSettings Settings
        {
            private set;
            get;
        }

        public abstract IDataProvider LoadDataProvider();
    }
}
