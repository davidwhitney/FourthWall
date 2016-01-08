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
<style>
.image {
    background-image: url('/Media/Random');
    background-size: cover;
    background-repeat: no-repeat;
    background-attachment: fixed;
    background-position: center;

    width: 100%; 
    height: 100%;     
}
</style>
</head>
<body>
<div class=""image"">
    &nbsp;
</div>
</body>
</html>
");
        }
    }
}
