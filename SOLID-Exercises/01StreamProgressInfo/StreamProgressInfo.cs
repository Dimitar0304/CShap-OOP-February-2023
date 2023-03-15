

using _P01.Stream_Progress;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private Streamer stremer;
        private List<IStreamer> streams;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(Streamer streamer)
        {

           stremer = streamer;



        }

        public int CalculateCurrentPercent()
        {
            return (this.stremer.BytesSent * 100) / this.stremer.Length;
        }
    }
}
