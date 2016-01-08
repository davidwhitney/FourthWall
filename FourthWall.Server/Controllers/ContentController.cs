using System.IO;
using System.Net.Http;
using System.Web.Http;
using FourthWall.Server.HttpResponses;

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
                return new NotFoundResponse();
            }

            return new FileFromDiskResponse(fullPath);
        }
    }
}
