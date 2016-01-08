using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthWall.Server.MediaSources
{
    public interface IMediaSource
    {
        List<string> List();
        byte[] FetchBytes(string image);
    }
}
