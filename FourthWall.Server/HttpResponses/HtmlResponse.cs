using System.Net;
using System.Net.Http;
using System.Text;

namespace FourthWall.Server.HttpResponses
{
    public class HtmlResponse : HttpResponseMessage
    {
        public HtmlResponse(string markup)
        {
            StatusCode = HttpStatusCode.OK;
            Content = new StringContent(markup, Encoding.UTF8, "text/html");
        }
    }
}