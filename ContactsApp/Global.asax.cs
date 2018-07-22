using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Contacts.Data.Access.DAL;
using Contacts.Queries;

namespace ContatctApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
           // Database.SetInitializer<DbContext>(new CreateDatabaseIfNotExists<DbContext>());
            //var applicationContainer = BuildContainer();
           
            //DependencyResolver.SetResolver(autofacDependencyResolver);
            //GlobalConfiguration.Configuration.DependencyResolver = autofacDependencyResolver;
        }


        //public Autofac.IContainer BuildContainer() 
        //{
        //    var builder = new ContainerBuilder();
        //    var controllersAssembly = Assembly.GetAssembly(typeof(HomeController));
        //    builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>();
        //    builder.RegisterType<ContactQueryProcessor>().As<IContactQueryProcessor>();
        //    //builder.RegisterControllers(Assembly.GetExecutingAssembly()).Inje
        //    return builder.Build();
        //}
    }
}