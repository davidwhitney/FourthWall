using System.Net;
using NUnit.Framework;

namespace FourthWall.Server.Test.Acceptance.Controllers
{
    public class ContentControllerTests : InMemoryTest
    {
        [Test]
        public void GetContent_FileExists_ReturnsContentFile()
        {
            var response = Http.GetString("/Content/JavaScript/test.js");

            Assert.That(response, Does.Contain("test"));
        }

        [Test]
        public void GetContent_FileDoesntExist_Returns404()
        {
            var response = Http.Get("/Content/i-dont-exist.js");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
