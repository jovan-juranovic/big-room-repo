using System.Web.Http;
using System.Web.Http.Dispatcher;
using BigRoom.Service.Common.Handlers;

namespace BigRoom.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            JwtAuthHandler jwtAuthHandler = new JwtAuthHandler
            {
                InnerHandler = new HttpControllerDispatcher(config)
            };

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/spa/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional},
                constraints: null,
                handler: jwtAuthHandler
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
