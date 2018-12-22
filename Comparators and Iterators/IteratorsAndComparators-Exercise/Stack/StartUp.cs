using System;
using System.Linq;

namespace Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(int.Parse)
                .ToArray();

            CustomStack<int> stack = new CustomStack<int>(numbers);

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    string[] data = input.Split();
                    int value = int.Parse(data[1]);
                    stack.Push(value);
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine(stack);
                Console.WriteLine(stack);
            }
        }
    }
}
