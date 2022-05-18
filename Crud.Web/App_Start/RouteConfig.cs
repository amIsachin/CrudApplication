using System.Web.Mvc;
using System.Web.Routing;

namespace Crud.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "all-students",
                url: "all-students",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "students-listing",
                url: "students-listing",
                defaults: new { controller = "Student", action = "StudentsListing", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "get-student",
                url: "Actions/{id}",
                defaults: new { controller = "Student", action = "Actions", id = UrlParameter.Optional },
                constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
