using System.Net;
using System.Net.Http;

namespace FourthWall.Server.HttpResponses
{
    public class RawResponse : HttpResponseMessage
    {
        public RawResponse(byte[] bytes)
        {
            StatusCode = HttpStatusCode.OK;
            Content = new ByteArrayContent(bytes);
        }
    }
}