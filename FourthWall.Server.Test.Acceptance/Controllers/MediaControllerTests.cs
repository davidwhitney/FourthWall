using System.Collections.Generic;
using FourthWall.Server.MediaSources;
using NUnit.Framework;

namespace FourthWall.Server.Test.Acceptance.Controllers
{
    [TestFixture]
    public class MediaControllerTests : InMemoryTest
    {
        [Test]
        public void Random_ByteArrayOfImageFromAMediaSource()
        {
            Mock<IMediaSource>().Setup(x => x.List()).Returns(new List<string> {"abc"});
            Mock<IMediaSource>().Setup(x => x.FetchBytes("abc")).Returns(new byte[] {0, 0, 0});

            var page = Http.GetBytes("/Media/Random");

            Assert.That(page, Is.EqualTo(new byte[] {0, 0, 0}));
        }
    }
}
