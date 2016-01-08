﻿using NUnit.Framework;

namespace FourthWall.Server.Test.Unit.Controllers
{
    public class HomeControllerTests : InMemoryTest
    {
        [Test]
        public void GetRoot_ReturnPageWithLinkToRandomImage()
        {
            var page = HttpClient.GetAsync("/").Result.Content.ReadAsStringAsync().Result;

            Assert.That(page, Does.Contain("('/Media/Random')"));
        }
    }
}
