using System.Web.Http;
using FourthWall.Server;
using Microsoft.Owin;
using Ninject;
using Ninject.Extensions.Conventions;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace FourthWall.Server
{
    public class Startup
    {
        public static StandardKernel Container { get; set; }

        public void Configuration(IAppBuilder appBuilder)
        {
            Container = new StandardKernel();
            Container.Bind(x => x.FromAssemblyContaining<Startup>().SelectAllClasses().BindAllInterfaces());

            var config = new HttpConfiguration
            {
                DependencyResolver = new DependencyResolver(Container)
            };

            Routes.Register(config.Routes);
            appBuilder.UseWebApi(config);
        }
    }
}