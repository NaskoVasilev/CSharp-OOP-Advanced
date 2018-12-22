using System;

namespace LinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            LinkedList<int> numbers = new LinkedList<int>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string command = data[0];
                int number = int.Parse(data[1]);

                if (command == "Add")
                {
                    numbers.Add(number);
                }
                else
                {
                    numbers.Remove(number);
                }
            }

            Console.WriteLine(numbers.Count);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
