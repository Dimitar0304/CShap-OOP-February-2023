

using _P01.Stream_Progress;

namespace P01.Stream_Progress
{
    public class Music:Streamer
    {
        private string artist;
        private string album;

        public Music( int length, int bytesSent) : base(length, bytesSent)
        {
        }
    }
}
