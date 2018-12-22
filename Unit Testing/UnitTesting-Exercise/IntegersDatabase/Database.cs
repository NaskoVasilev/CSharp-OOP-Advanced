using System;
using System.Linq;

namespace IntegersDatabase
{
    public class Database
    {
        private int[] data;
        private const int Capacity = 16;
        private int lastIndex;

        public Database()
        {
            this.data = new int[Capacity];
            lastIndex = -1;
        }

        public Database(int[] elements):this()
        {
            if (elements.Length > Capacity)
            {
                throw new InvalidOperationException($"Input array length must be smaller than {Capacity}");
            }

            Array.Copy(elements, data, elements.Length);
            this.lastIndex = elements.Length - 1;
        }

        public void Add(int element)
        {
            if (this.lastIndex >= Capacity - 1)
            {
                throw new InvalidOperationException("Database is full!");
            }

            this.data[++this.lastIndex] = element;
        }

        public void Remove()
        {
            if (this.lastIndex == -1)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.data[lastIndex--] = default(int);
        }

        public int[] Fetch()
        {
            return this.data.Take(this.lastIndex + 1).ToArray();
        }
    }
}
