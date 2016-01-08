using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

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
            var msg = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
<html><head>
<title>Home</title>
</head>
<body><img src=""/Media/Random"" style=""width: 100%;"" /></body>
</html>
", Encoding.UTF8, "text/html")
            };

            return msg;
        }
    }
}
