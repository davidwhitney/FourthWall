using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FourthWall.Server.MediaSources;

namespace FourthWall.Server.Controllers
{
    public class MediaController : ApiController
    {
        private readonly IEnumerable<IMediaSource> _sources;

        public MediaController(IEnumerable<IMediaSource> sources)
        {
            _sources = sources;
        }

        [HttpGet]
        public HttpResponseMessage Random()
        {
            var mediaSource = _sources.Random();

            var candidates = mediaSource.List();
            var randomImage = candidates.Random();
            var bytes = mediaSource.FetchBytes(randomImage);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(bytes)
            };
        }
    }
}
