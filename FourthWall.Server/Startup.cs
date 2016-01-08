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
            Routes.Register(config.Routes);
            appBuilder.UseWebApi(config);
        }
    }
}