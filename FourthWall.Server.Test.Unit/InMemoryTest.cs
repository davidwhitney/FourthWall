using System;
using System.Net.Http;
using FourthWall.Server.Bootstrapping;
using Microsoft.Owin.Hosting;
using Ninject;
using NUnit.Framework;

namespace FourthWall.Server.Test.Unit
{
    [TestFixture]
    public abstract class InMemoryTest
    {
        private EmbeddedWebServer _server;
        private IKernel _container;
        public string BaseUrl => _server.BaseUrl;
        public HttpClient HttpClient { get; set; }

        [SetUp]
        public void SetUp()
        {
            _container = ContainerBuilder.CreateContainer();
            _server = new EmbeddedWebServer(_container);
            HttpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
        }

        [TearDown]
        public void TearDown()
        {
            _server.Dispose();
        }
    }
}
