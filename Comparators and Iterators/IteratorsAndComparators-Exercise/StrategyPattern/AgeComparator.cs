using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}
