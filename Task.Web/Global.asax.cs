using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Task.Data.Infrastructure;
using Task.Data.Migrations;
using Task.Data.Repositories;
using Task.Service;
using Task.Web.Mapping;


namespace Task.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            

            //System.Data.Entity.Database.SetInitializer(new Configuration());
           
                var builder = new ContainerBuilder();
                builder.RegisterControllers(Assembly.GetExecutingAssembly());
                builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
                builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

                // Repositories

                builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerRequest();

                // Services
                builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerRequest();

                IContainer container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperWebProfile.Run();
        }
    }
}
