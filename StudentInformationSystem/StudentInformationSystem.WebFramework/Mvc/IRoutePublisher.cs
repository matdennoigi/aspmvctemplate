using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace StudentInformationSystem.WebFramework.Mvc
{
    public interface IRoutePublisher
    {
        void RegisterRoutes(RouteCollection routes);
    }
}
