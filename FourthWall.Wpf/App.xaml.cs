using System.Windows;
using FourthWall.Server;
using FourthWall.Server.Bootstrapping;
using Ninject;

namespace FourthWall.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IKernel Container { get; set; }
        public static EmbeddedWebServer Server { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Container = ContainerBuilder.CreateContainer();
            Server = new EmbeddedWebServer(Container);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Server.Dispose();
        }
    }
}
