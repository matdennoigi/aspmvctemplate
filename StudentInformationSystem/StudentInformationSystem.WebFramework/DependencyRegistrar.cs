using StudentInformationSystem.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Core.Configuration;
using StudentInformationSystem.Core.Infrastructure;
using Autofac;
using StudentInformationSystem.Core.Data;
using StudentInformationSystem.Data;
using System.Web;
using StudentInformationSystem.Services.Authentication;
using Autofac.Integration.Mvc;
using StudentInformationSystem.Services.Students;
using StudentInformationSystem.Services.Security;
using StudentInformationSystem.WebFramework.Mvc;

namespace StudentInformationSystem.WebFramework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {

        public void Register(ContainerBuilder containerBuilder, ITypeFinder typeFinder, AppConfig appConfig)
        {
            // Http Context
            containerBuilder.Register(c =>
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (null))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();

            // Controllers
            containerBuilder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            // DAL
            DataSettingsManager dataSettingsManager = new DataSettingsManager();
            var dataSettings = dataSettingsManager.LoadSettings();
            containerBuilder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            containerBuilder.Register(c => new EfDataProviderManager(c.Resolve<DataSettings>()))
                .As<BaseDataProviderManager>().InstancePerDependency();

            containerBuilder.Register(c => c.Resolve<BaseDataProviderManager>().LoadDataProvider())
                .As<IDataProvider>().InstancePerDependency();

            if (dataSettings != null && dataSettings.IsValid())
            {
                var efDataProviderManager = new EfDataProviderManager(dataSettings);
                var dataProvider = efDataProviderManager.LoadDataProvider();
                dataProvider.InitConnectionFactory();

                containerBuilder.Register<IDbContext>(c => new AppObjectContext(dataSettings.DataConnectionString)).InstancePerLifetimeScope();
            }
            else
            {
                containerBuilder.Register<IDbContext>(c => new AppObjectContext(dataSettingsManager.LoadSettings().DataConnectionString))
                    .InstancePerLifetimeScope();
            }

            containerBuilder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //Service
            containerBuilder.RegisterType<FormAuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<StudentRegistrationService>().As<IStudentRegistrationService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerLifetimeScope();

            //Route Publisher
            containerBuilder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();

            
        }

        public int Order
        {
            get { return 0; }
        }

    }
}
