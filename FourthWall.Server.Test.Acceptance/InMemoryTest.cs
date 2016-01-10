using FourthWall.Server.Bootstrapping;
using Moq;
using Ninject;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace FourthWall.Server.Test.Acceptance
{
    [TestFixture]
    public abstract class InMemoryTest
    {
        private EmbeddedWebServer _server;
        private IKernel _container;
        private Fixture _af;
        public string BaseUrl => _server.BaseUrl;
        public TestClient Http { get; set; }

        [SetUp]
        public void SetUp()
        {
            _af = new Fixture();
            _container = ContainerBuilder.CreateContainer();
            _server = new EmbeddedWebServer(_container);
            Http = new TestClient(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            _server.Dispose();
        }

        public Mock<T> Mock<T>() where T : class
        {
            var dep = _af.Freeze<Mock<T>>();
            _container.Rebind<T>().ToMethod(x => dep.Object);
            return dep;
        }
    }
}
