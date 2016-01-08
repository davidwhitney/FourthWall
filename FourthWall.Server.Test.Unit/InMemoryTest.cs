using System;
using System.Net.Http;
using NUnit.Framework;

namespace FourthWall.Server.Test.Unit
{
    [TestFixture]
    public abstract class InMemoryTest
    {
        private EmbeddedWebServer _server;
        public string BaseUrl => _server.BaseUrl;
        public HttpClient HttpClient { get; set; }

        [SetUp]
        public void SetUp()
        {
            _server = new EmbeddedWebServer();
            HttpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
        }

        [TearDown]
        public void TearDown()
        {
            _server.Dispose();
        }
    }
}
