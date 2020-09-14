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

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);     
        }
        
    }
}
