using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StudentInformationSystem.Core.Configuration
{
    public class AppConfig : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            AppConfig appConfig = new AppConfig();
            return appConfig;
        }
    }
}
