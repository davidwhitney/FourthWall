using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Http;
using FourthWall.Server;
using FourthWall.Server.Controllers;
using FourthWall.Server.MediaSources;
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
            CreateContainer();

            var config = new HttpConfiguration
            {
                DependencyResolver = new DependencyResolver(Container)
            };

            Routes.Register(config.Routes);
            appBuilder.UseWebApi(config);
        }

        private static void CreateContainer()
        {
            Container = new StandardKernel();
            Container.Bind(x => x.FromAssemblyContaining<Startup>().SelectAllClasses().BindToSelf());
            Container.Bind(x =>
            {
                x.FromAssemblyContaining<Startup>()
                    .SelectAllClasses()
                    .Excluding<CachingMediaSource>()
                    .BindAllInterfaces();
            });

            Container.Rebind<MediaSourceList>()
                .ToMethod(x =>
                {
                    var mediaSources = x.Kernel.GetAll<IMediaSource>();
                    var sources = new MediaSourceList();
                    sources.AddRange(mediaSources.Select(s => new CachingMediaSource(s)));
                    return sources; 
                });
        }
    }
}