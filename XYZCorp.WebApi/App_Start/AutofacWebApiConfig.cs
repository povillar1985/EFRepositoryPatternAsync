using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using XYZCorp.Core.Repositories;
using XYZCorp.Repository;
using XYZCorp.Repository.Repositories;
using XYZCorp.WebApi.Controllers;

namespace XYZCorp.WebApi.App_Start
{
    public class AutofacWebApiConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config) {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container) {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder) {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterType<ValuesController>().As<IValuesController>().InstancePerDependency();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerDependency();
            builder.RegisterType<XYZDbContext>().AsSelf().InstancePerDependency();

            Container = builder.Build();

            return Container;
        }
    }

    public class Bootstrapper
    {
        public static void Run() {
            AutofacWebApiConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}