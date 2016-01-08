using System.Web.Http;
using FourthWall.Server;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace FourthWall.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute("Home", "", new { controller = "Home", action = "index"}, new {});
            config.Routes.MapHttpRoute("Content", "Content/{*path}", new { controller = "Content", action = "index"}, new {});
            config.Routes.MapHttpRoute("Default", "{controller}/{action}", new { controller = "Home", action = "index"}, new {});

            appBuilder.UseWebApi(config);
        }
    }
}