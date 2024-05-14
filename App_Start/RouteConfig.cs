using Microsoft.Identity.Client;
using System.Security.Policy;
using System.Web.Mvc;

namespace BellsLibrary.App_Start
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Name",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}
