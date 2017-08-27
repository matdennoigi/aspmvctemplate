using StudentInformationSystem.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace StudentInformationSystem.WebFramework.Mvc
{
    public class RoutePublisher : IRoutePublisher
    {
        private ITypeFinder typeFinder;
        public RoutePublisher(ITypeFinder typeFinder)
        {
            this.typeFinder = typeFinder;
        }

        public void RegisterRoutes(RouteCollection routes)
        {
            var routeProviderTypes = typeFinder.FindClassesOfType<IRouteProvider>();
            var routeProviders = new List<IRouteProvider>();
            foreach (var routeProviderType in routeProviderTypes)
            {
                routeProviders.Add(Activator.CreateInstance(routeProviderType) as IRouteProvider);
            }
            routeProviders = routeProviders.OrderByDescending(provider => provider.Priority).ToList();
            routeProviders.ForEach(provider => provider.RegisterRoutes(routes));
        }
    }
}
