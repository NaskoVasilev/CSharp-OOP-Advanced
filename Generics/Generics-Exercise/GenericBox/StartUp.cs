using System;

namespace GenericBox
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int item = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(item);
                Console.WriteLine(box);
            }
        }
    }
}
