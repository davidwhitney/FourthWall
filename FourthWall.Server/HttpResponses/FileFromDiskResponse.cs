using System.IO;
using System.Net;
using System.Net.Http;

namespace FourthWall.Server.HttpResponses
{
    public class FileFromDiskResponse : HttpResponseMessage
    {
        public FileFromDiskResponse(string path)
        {
            Content = new ByteArrayContent(File.ReadAllBytes(path));
            StatusCode = HttpStatusCode.OK;
        }
    }
}
