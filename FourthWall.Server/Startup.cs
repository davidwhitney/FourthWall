using System.Web.Http;
using FourthWall.Server;
using FourthWall.Server.Bootstrapping;
using Microsoft.Owin;
using Ninject;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace FourthWall.Server
{
    public class Startup
    {
        public static IKernel Container { get; set; }

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration
            {
                DependencyResolver = new DependencyResolver(Container)
            };

            Routes.Register(config.Routes);
            appBuilder.UseWebApi(config);
        }

    }
}