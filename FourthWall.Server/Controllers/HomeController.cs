using System.Net.Http;
using System.Web.Http;
using FourthWall.Server.HttpResponses;

namespace FourthWall.Server.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            return new ViewResponse("Image.cshtml");
        }
    }
}
