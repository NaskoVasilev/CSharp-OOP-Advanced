using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethod
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> elements = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int item = int.Parse(Console.ReadLine());
                elements.Add(item);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(elements, indexes[0], indexes[1]);

            foreach (var item in elements)
            {
                Console.WriteLine($"{item.GetType().FullName}: {item}");
            }
        }

        private static void Swap<T>(List<T> elements, int index1, int index2)
        {
            T tempValue = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = tempValue;
        }
    }
}
