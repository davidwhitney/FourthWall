using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using FourthWall.Server.HttpResponses;

namespace FourthWall.Server.Controllers
{
    public class HomeController : ApiController
    {
        public HomeController()
        {
            
        }

        [HttpGet]
        public HttpResponseMessage Index()
        {
            return new HtmlResponse(@"<html>
<head>
<title>Home</title>
</head>
<body><img src=""/Media/Random"" style=""width: 100%;"" /></body>
</html>
");
        }
    }
}
