using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Web.Routing;
using WebMotorsDesafio.Contracts;
using WebMotorsDesafio.Controllers;
using WebMotorsDesafio.Repositories;

namespace WebMotorsDesafio
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<AnuncioRepository>().As<IAnuncioRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));          
        }
    }
}
