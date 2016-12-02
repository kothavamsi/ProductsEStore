using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;
using ProductsEStore.LogHandler;
using ProductsEStore.LogHandler.LogSettingsHandler;
using ProductsEStore.PagerHandler.Config;
using ProductsEStore.Repository;
using ProductsEStore.Repository.MemoryChache;
using ProductsEStore.Repository.SqlServerDB;
using ProductsEStore.SiteMap;

namespace ProductsEStore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801


    public class MvcApplication : NinjectHttpApplication
    {
        public static IKernel DIContainer;
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            
            kernel.Bind<ICacheService>().To<InMemoryCache>();
            kernel.Bind<IRepository>().To<SqlServerDbRepository>();
            DIContainer = kernel;
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            LogSettingsManager.LoadSettings();
            LogManager.Initalize();
            //BooksLocationSettingsManager.LoadSettings();
            PagerSettingsManager.LoadSettings();
            SiteMapSettingsManager.LoadSettings();
        }
    }

    //public class MvcApplication : System.Web.HttpApplication
    //{
    //    protected void Application_Start()
    //    {
    //        AreaRegistration.RegisterAllAreas();

    //        WebApiConfig.Register(GlobalConfiguration.Configuration);
    //        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    //        RouteConfig.RegisterRoutes(RouteTable.Routes);
    //        BundleConfig.RegisterBundles(BundleTable.Bundles);
    //        AuthConfig.RegisterAuth();

    //        LogSettingsManager.LoadSettings();
    //        LogManager.Initalize();
    //        //BooksLocationSettingsManager.LoadSettings();
    //        PagerSettingsManager.LoadSettings();
    //        SiteMapSettingsManager.LoadSettings();
    //    }
    //}
}