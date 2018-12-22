using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            int result = first.Name.Length.CompareTo(second.Name.Length);

            if (result == 0)
            {
                char firstPersonFirstLetter = char.ToLower(first.Name[0]);
                char secondPersonFirstLetter = char.ToLower(second.Name[0]);

                result = firstPersonFirstLetter.CompareTo(secondPersonFirstLetter);
            }

            return result;
        }
    }
}
