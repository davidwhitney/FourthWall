using NUnit.Framework;

namespace FourthWall.Server.Test.Acceptance.Controllers
{
    public class HomeControllerTests : InMemoryTest
    {
        [Test]
        public void GetRoot_ReturnPageWithLinkToRandomImage()
        {
            var page = Http.GetString("/");

            Assert.That(page, Does.Contain("('/Media/Random')"));
        }
    }
}
