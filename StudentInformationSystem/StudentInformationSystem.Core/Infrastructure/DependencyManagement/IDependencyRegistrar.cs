using Autofac;
using StudentInformationSystem.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.Infrastructure.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder, AppConfig appConfig);

        int Order { get; }
    }
}
