using System;
using System.Collections.Generic;

namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] array = ArrayCreator.Create(10, 7);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            string[] names = ArrayCreator.Create<string>(5, "Atanas");

            Console.WriteLine(string.Join(", ", names));
        }
    }
}
