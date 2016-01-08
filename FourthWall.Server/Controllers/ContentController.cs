using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FourthWall.Server.Controllers
{
    public class ContentController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index(string path)
        {
            path = path.Replace("/", "\\");
            var fullPath = Path.Combine(@"C:\Dev\FourthWall\FourthWall.Server\Content", path); // LOL HAX

            if (!File.Exists(fullPath))
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(File.ReadAllBytes(fullPath))
            };
        }
    }
}
