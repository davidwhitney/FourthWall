using System.Net;
using System.Net.Http;

namespace FourthWall.Server.HttpResponses
{
    public class NotFoundResponse : HttpResponseMessage
    {
        public NotFoundResponse()
        {
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}