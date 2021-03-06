using System.IO.Abstractions;
using System.Linq;
using FourthWall.Server.MediaSources;
using Ninject;
using Ninject.Extensions.Conventions;

namespace FourthWall.Server.Bootstrapping
{
    public static class ContainerBuilder
    {
        public static IKernel CreateContainer()
        {
            var container = new StandardKernel();
            container.Bind(x => x.FromAssemblyContaining<Startup>().SelectAllClasses().BindToSelf());
            container.Bind(x => x.FromAssemblyContaining<IFileSystem>().SelectAllClasses().BindAllInterfaces());

            container.Bind(x =>
            {
                x.FromAssemblyContaining<Startup>()
                    .SelectAllClasses()
                    .Excluding<CachingMediaSource>()
                    .BindAllInterfaces();
            });

            container.Rebind<MediaSourceList>()
                .ToMethod(x =>
                {
                    var mediaSources = x.Kernel.GetAll<IMediaSource>();
                    var sources = new MediaSourceList();
                    sources.AddRange(mediaSources.Select(s => x.Kernel.Get<CachingMediaSource>().WithSource(s)));
                    return sources;
                });

            container.Rebind<ServerConfiguration>()
                .ToMethod(x => x.Kernel.Get<ServerConfigurationLoader>().GetConfiguration())
                .InSingletonScope();

            return container;
        }
    }
}