using Publishers.API.Routing;
using System.Web.Http;

namespace Publishers.API.Config
{
    public static class RouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var routes = config.Routes;

            routes.MapHttpRoute(
                name: "SingleBookRoute",
                routeTemplate: "api/single_book/{id}",
                defaults: new { controller = "Books", action = "GetById" },
                constraints: new { id = new ObjectIdRouteConstraint() }
            );

            routes.MapHttpRoute(
                name: "AllBooksRoute",
                routeTemplate: "api/all_books",
                defaults: new { controller = "Books", action = "Get" }
            );

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = new ObjectIdRouteConstraint() }
            );
        }
    }
}
