using System.Collections.Generic;
using System.IO.Abstractions;

namespace FourthWall.Server.MediaSources
{
    public class CachingMediaSource : IMediaSource
    {
        private IMediaSource _inner;
        private readonly ServerConfiguration _configuration;
        private readonly IFileSystem _fs;

        public CachingMediaSource(ServerConfiguration configuration, IFileSystem fs)
        {
            _configuration = configuration;
            _fs = fs;
        }

        public CachingMediaSource WithSource(IMediaSource inner)
        {
            _inner = inner;
            return this;
        }

        public List<string> List()
        {
            var cacheKey = _inner.GetType().Name;
            if (_fs.File.Exists(_fs.Path.Combine(_configuration.TemporaryStoragePath, cacheKey)))
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
