using System.Windows;
using FourthWall.Server;

namespace FourthWall.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EmbeddedWebServer Server { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Server = new EmbeddedWebServer();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Server.Dispose();
        }
    }
}
