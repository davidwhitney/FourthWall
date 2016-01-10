using System.IO;
using System.IO.Abstractions;

namespace FourthWall.Server
{
    public class ServerConfigurationLoader
    {
        private readonly IFileSystem _fs;
        private readonly string _temp;

        public ServerConfigurationLoader(IFileSystem fs)
        {
            _fs = fs;
            _temp = Path.GetTempPath();
        }

        public ServerConfiguration GetConfiguration()
        {
            var config = new ServerConfiguration
            {
                TemporaryStoragePath = Path.Combine(_temp, "FourthWallTemp")
            };

            if (!_fs.Directory.Exists(config.TemporaryStoragePath))
            {
                _fs.Directory.CreateDirectory(config.TemporaryStoragePath);
            }

            return config;
        }
    }
}