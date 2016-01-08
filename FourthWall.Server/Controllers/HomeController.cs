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
            return new HtmlResponse(@"<html>
<head>
<title>Home</title>
</head>
<body>
<div style=""width: 100%; height: 100%; background-image: url('/Media/Random'); background-size: cover;"">
    &nbsp;
</div>
</body>
</html>
");
        }
    }
}
