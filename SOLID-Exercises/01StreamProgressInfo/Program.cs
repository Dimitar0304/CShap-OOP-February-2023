

using _P01.Stream_Progress;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {

            string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //Streamer streamer = new Music( int.Parse(info[2]), int.Parse(info[3]));
            Streamer fileSteamer = new File(info[0], int.Parse(info[1]), int.Parse(info[2]));

            StreamProgressInfo streamProgInfo = new StreamProgressInfo(fileSteamer);

            Console.WriteLine(streamProgInfo.CalculateCurrentPercent());
        }
    }
}
