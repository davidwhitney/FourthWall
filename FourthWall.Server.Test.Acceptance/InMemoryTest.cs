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

        protected TestClient Http { get; private set; }

        [SetUp]
        public void SetUp()
        {
            _af = new Fixture();
            _container = ContainerBuilder.CreateContainer();
            _server = new EmbeddedWebServer(_container);
            Http = new TestClient(_server.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            _server.Dispose();
        }

        protected Mock<T> Mock<T>() where T : class
        {
            var dep = _af.Freeze<Mock<T>>();
            _container.Rebind<T>().ToMethod(x => dep.Object);
            return dep;
        }
    }
}
