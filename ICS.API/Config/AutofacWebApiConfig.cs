using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ICS.API.Config
{
    public static class AutofacWebApiConfig
    {
        public static void Initialize(HttpConfiguration config)
        {

            Initialize(config,
                RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(
            HttpConfiguration config, IContainer container)
        {

            config.DependencyResolver =
                new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // registration goes here

            return builder.Build();
        }
    }
}
