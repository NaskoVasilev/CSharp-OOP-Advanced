using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person()
        {
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Person otherPerson)
            {
                return this.Name == otherPerson.Name
                    && this.Age == otherPerson.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

        public int CompareTo(Person other)
        {
            int result =  this.Name.CompareTo(other.Name);

            if(result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }
    }
}
