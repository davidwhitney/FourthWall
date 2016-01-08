using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace FourthWall.Server.MediaSources.Unsplash
{
    public class UpsplashMediaSource : IMediaSource
    {
        public List<string> List()
        {
            var xdoc = XDocument.Load("https://unsplash.com/rss");
            var descriptions = xdoc.Descendants().Where(x => x.Name == "description").ToList();

            var uri = new List<string>();
            foreach (var item in descriptions)
            {
                var capture = Regex.Match(item.Value, "src=\"(.+)\" title");
                if (capture.Success)
                {
                    uri.Add(capture.Groups[1].Value);
                }

            }

            return uri;
        }

        public byte[] FetchBytes(string image)
        {
            var client = new HttpClient();
            return client.GetByteArrayAsync(image).Result;
        }
    }
}
