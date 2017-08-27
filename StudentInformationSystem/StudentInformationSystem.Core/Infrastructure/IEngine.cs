using StudentInformationSystem.Core.Configuration;
using StudentInformationSystem.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Core.Infrastructure
{
    public interface IEngine
    {
        ContainerManager ContainerManager { get; }

        void Initialize(AppConfig appConfig);

        T Resolve<T>() where T : class;

        object Resolve(Type type);

    }
}
