using System;
using System.Collections.Generic;

namespace GenericCountMethod
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> elements = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                elements.Add(element);
            }

            double inputItem = double.Parse(Console.ReadLine());

            Console.WriteLine(GetGreaterCount(elements,inputItem));
        }

        private static int GetGreaterCount<T>(List<T> elements, T inputItem) where T : IComparable<T>
        {
            int counter = 0;
            foreach (var element in elements)
            {
                if (element.CompareTo(inputItem) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
