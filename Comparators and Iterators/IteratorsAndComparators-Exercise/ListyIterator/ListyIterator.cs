using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int currentIndex;
        private List<T> elements;

        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if(HasNext())
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return currentIndex < this.elements.Count - 1;
        }

        public void Print()
        {
            if(this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
