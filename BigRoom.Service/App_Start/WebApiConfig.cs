using System.Web.Http;

namespace BigRoom.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/spa/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            config.Routes.MapHttpRoute(
                name: "AdminAPI",
                routeTemplate: "api/v1/mvc/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            config.EnableCors();
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
