using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStreamable music = new Music("Pesho", "Album", 10, 500);
            IStreamable file = new File("My file", 12, 800);

            StreamProgressInfo musicProgress = new StreamProgressInfo(music);
            Console.WriteLine(musicProgress.CalculateCurrentPercent());

            StreamProgressInfo fileProgress = new StreamProgressInfo(file);
            Console.WriteLine(fileProgress.CalculateCurrentPercent());
        }
    }
}
