using HomeCinema.Web.MessageHandlers;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace HomeCinema.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            
            // Web API configuration and services
            config.MessageHandlers.Add(new HomeCinemaAuthHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
