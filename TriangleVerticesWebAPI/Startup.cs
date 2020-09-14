using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(TriangleVerticesWebAPI.Startup))]
namespace TriangleVerticesWebAPI
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; set; } = new HttpConfiguration();
        public void Configuration(IAppBuilder app)
        {
            var config = Startup.HttpConfiguration;
            ConfigureWebAPI(app, config);
            // Configure Web API for self-host. 
            //HttpConfiguration config = new HttpConfiguration();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            ////var jsonFormatter = config.Formatters.JsonFormatter;
            ////jsonFormatter.UseDataContractJsonSerializer = false;
            ////var settings = jsonFormatter.SerializerSettings;
            ////settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            ////settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //app.UseWebApi(config);
        }

        private static void ConfigureWebAPI(IAppBuilder app, HttpConfiguration config)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }
}
