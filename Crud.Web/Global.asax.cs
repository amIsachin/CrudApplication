using Microsoft.Web.WebPages.OAuth;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Crud.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public class OAuthConfig
        {
            public static void RegisterProviders()
            {
                OAuthWebSecurity.RegisterGoogleClient();
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //--> This reference Coming From UnityConfig Class.
            UnityConfig.RegisterComponents();

            OAuthConfig.RegisterProviders();

            //--> Add Global authorize attribute
            //GlobalFilters.Filters.Add(new AuthorizeAttribute());
        }
    }
}