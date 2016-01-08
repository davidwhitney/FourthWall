using System;
using System.Collections.Generic;
using System.Linq;
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
            var candidates = _sources.First().List();
            var random = candidates.OrderBy(x => Guid.NewGuid()).First();
            var bytes = _sources.First().FetchBytes(random);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(bytes)
            };
        }
    }
}
