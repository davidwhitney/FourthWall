using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.Owin.Hosting;

namespace FourthWall.Server
{
    public class EmbeddedWebServer : IDisposable
    {
        public string BaseUrl { get; }
        private readonly IDisposable _app;

        public EmbeddedWebServer()
        {
            var port = FreeTcpPort();
            BaseUrl = "http://localhost:" + port;
            _app = WebApp.Start<Startup>(BaseUrl);
        }

        private static int FreeTcpPort()
        {
            var l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            var port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }

        public void Dispose()
        {
            _app.Dispose();
        }
    }
}