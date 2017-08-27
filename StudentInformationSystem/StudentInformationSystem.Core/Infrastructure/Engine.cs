using StudentInformationSystem.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Core.Infrastructure.DependencyManagement;
using Autofac;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace StudentInformationSystem.Core.Infrastructure
{
    public class Engine : IEngine
    {
        private ContainerManager containerManager;

        public ContainerManager ContainerManager
        {
            get { return containerManager; }
        }

        public void Initialize(AppConfig appConfig)
        {
            RegisterDependencies(appConfig);

            RegisterMapperConfiguration(appConfig);

            RunStartupTasks();
        }

        protected virtual void RegisterDependencies(AppConfig appConfig)
        {
            var containerBuilder = new ContainerBuilder();

            var typeFinder = new WebAppTypeFinder();
            containerBuilder.RegisterInstance(appConfig).As<AppConfig>().SingleInstance();
            containerBuilder.RegisterInstance(this).As<IEngine>().SingleInstance();
            containerBuilder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var drInstances = new List<IDependencyRegistrar>();
            foreach (var drType in drTypes)
                drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));

            // Sort
            drInstances = drInstances.AsQueryable().OrderBy(item => item.Order).ToList();
            foreach (var dependencyRegistrar in drInstances)
                dependencyRegistrar.Register(containerBuilder, typeFinder, appConfig);

            var container = containerBuilder.Build();
            this.containerManager = new ContainerManager(container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected virtual void RunStartupTasks()
        {
            var typeFinder = ContainerManager.Resolve<ITypeFinder>();
            var startupTaskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            var startupTaskInstances = new List<IStartupTask>();
            foreach (var startupTaskType in startupTaskTypes)
                startupTaskInstances.Add((IStartupTask)Activator.CreateInstance(startupTaskType));

            startupTaskInstances = startupTaskInstances.AsQueryable().OrderBy(item => item.Order).ToList();
            foreach (var startupTask in startupTaskInstances)
                startupTask.Execute();
        }

        protected virtual void RegisterMapperConfiguration(AppConfig appConfig)
        {
        }

        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }

        
    }
}
