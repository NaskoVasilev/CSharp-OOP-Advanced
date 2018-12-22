using System;
using System.Collections.Generic;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                string town = data[2];

                people.Add(new Person(name, age, town));
            }

            int targetIndex = int.Parse(Console.ReadLine());
            targetIndex--;

            Person targetPerson = people[targetIndex];
            PersonStatistics personStatistics = new PersonStatistics(people);
            int matches = personStatistics.GetEqualPeopleCount(targetPerson);

            if (matches <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {personStatistics.GetNotEqualPeopleCount(targetPerson)} {people.Count}");
            }
        }

    }
}
