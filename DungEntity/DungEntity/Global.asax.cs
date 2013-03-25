using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DungEntity.Models;
using System.Data.Entity;
using DungEntity.Migrations;
using Domain.RepositoryInterface;
using Microsoft.Practices.Unity;
using EF;
using Unity.Mvc3;

namespace DungEntity
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

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
            var context = new Context();
            context.Database.Initialize(true);

            var container = new UnityContainer();
            container.RegisterType<IContactRepository, ContactRepository>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}