using System.Collections.Generic;

namespace FourthWall.Server.MediaSources
{
    public interface IMediaSource
    {
        List<string> List();
        byte[] FetchBytes(string image);
    }
}
