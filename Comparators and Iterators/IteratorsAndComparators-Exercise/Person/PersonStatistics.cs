using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class PersonStatistics
    {
        private List<Person> people;

        public PersonStatistics(List<Person> people)
        {
            this.people = people;
        }

        public int GetEqualPeopleCount(Person person)
        {
            int counter = 0;

            foreach (var currentPerson in people)
            {
                if (person.CompareTo(currentPerson) == 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public int GetNotEqualPeopleCount(Person person)
        {
            return this.people.Count -  this.GetEqualPeopleCount(person);
        }
    }
}
