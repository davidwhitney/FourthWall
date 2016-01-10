using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthWall.Server.MediaSources
{
    public class CachingMediaSource : IMediaSource
    {
        private readonly IMediaSource _inner;

        public CachingMediaSource(IMediaSource inner)
        {
            _inner = inner;
        }

        public List<string> List()
        {
            var cachePath = @"C:\Dev\FourthWall\FourthWall.Server\MediaSourceCache";
            var cacheKey = _inner.GetType().Name;
            if (File.Exists(Path.Combine(cachePath, cacheKey)))
            {
                
            }

            return _inner.List();
        }

        public byte[] FetchBytes(string image)
        {
            return _inner.FetchBytes(image);
        }
    }
}
