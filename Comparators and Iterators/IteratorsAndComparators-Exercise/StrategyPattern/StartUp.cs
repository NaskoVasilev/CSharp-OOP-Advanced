using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> uniquePeople = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                Person person = new Person(data[0], int.Parse(data[1]));

                sortedPeople.Add(person);
                uniquePeople.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(uniquePeople.Count);
        }

        private static void PrintCollection(IEnumerable<Person> collection)
        {
            Console.WriteLine(string.Join(Environment.NewLine, collection));
        }
    }
}
