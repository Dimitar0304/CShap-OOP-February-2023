using P01.Stream_Progress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P01.Stream_Progress
{
    public abstract class Streamer : IStreamer
    {
        protected Streamer(int length, int bytesSent)
        {
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; set ; }
        public int BytesSent { get; set ; }
    }
}
