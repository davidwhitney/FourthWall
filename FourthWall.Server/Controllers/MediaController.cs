using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using FourthWall.Server.MediaSources;
using FourthWall.Server.MediaSources.Unsplash;

namespace FourthWall.Server.Controllers
{
    public class MediaController : ApiController
    {
        private readonly IMediaSource _mediaSource;

        public MediaController()
        {
            _mediaSource = new UpsplashMediaSource();
        }

        [HttpGet]
        public HttpResponseMessage Random()
        {
            var candidates = _mediaSource.List();
            var random = candidates.OrderBy(x => Guid.NewGuid()).First();
            var bytes = _mediaSource.FetchBytes(random);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(bytes)
            };
        }
    }
}
