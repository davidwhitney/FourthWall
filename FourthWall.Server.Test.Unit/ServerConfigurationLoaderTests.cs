using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using NUnit.Framework;

namespace FourthWall.Server.Test.Unit
{
    [TestFixture]
    public class ServerConfigurationLoaderTests
    {
        private ServerConfigurationLoader _loader;
        private MockFileSystem _fsMock;

        [SetUp]
        public void SetUp()
        {
            _fsMock = new MockFileSystem(new Dictionary<string, MockFileData>());
            _loader = new ServerConfigurationLoader(_fsMock);
        }

        [Test]
        public void GetConfiguration_TempDirIsPopulated()
        {
            var cfg = _loader.GetConfiguration();

            Assert.That(cfg.TemporaryStoragePath, Does.EndWith("FourthWallTemp"));
            Assert.That(cfg.TemporaryStoragePath, Does.Contain("AppData"));
            Assert.That(cfg.TemporaryStoragePath, Does.Contain("Temp"));
        }

        [Test]
        public void GetConfiguration_TempDirGetsCreatedIfItDoesntExist()
        {
            var cfg = _loader.GetConfiguration();

            Assert.That(_fsMock.Directory.Exists(cfg.TemporaryStoragePath));
        }
    }
}
