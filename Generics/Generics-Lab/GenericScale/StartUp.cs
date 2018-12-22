using System;
using System.Collections.Generic;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Scale<Peron<int>> scale = new Scale<Peron<int>>(new Peron<int>(), new Peron<int>());
            Console.WriteLine(scale.GetHeavier());
        }

        public class Peron<T> : IComparable<Peron<T>>
        {
            public int CompareTo(Peron<T> other)
            {
                throw new NotImplementedException();
            }
        }
    }
}
