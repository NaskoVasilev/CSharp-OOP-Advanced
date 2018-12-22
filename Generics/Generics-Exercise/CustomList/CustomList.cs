using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomList
{
    public class CustomList<T> : ICustomList<T> where T : IComparable<T>
    {
        private const int deafautCapacity = 4;

        private T[] array;

        public CustomList(int capacity = deafautCapacity)
        {
            this.array = new T[capacity];
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Count == this.array.Length)
            {
                this.Resize();
            }

            this.array[this.Count++] = element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public int CountGreaterThan(T element)
        {
            int counter = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (array[i].CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            CheckEmptyList();

            T maxElement = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (array[i].CompareTo(maxElement) > 0)
                {
                    maxElement = array[i];
                }
            }

            return maxElement;
        }

        public T Min()
        {
            CheckEmptyList();

            T minElement = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (array[i].CompareTo(minElement) < 0)
                {
                    minElement = array[i];
                }
            }

            return minElement;
        }

        public T Remove(int index)
        {
            CheckIndexes(index);

            T element = this.array[index];
            this.array[index] = default(T);
            this.Count--;
            this.ShiftLeft(index);

            if (this.array.Length > this.Count)
            {
                this.array[this.Count] = default(T);
            }

            if (this.Count < this.array.Length / 4)
            {
                this.Shrink();
            }

            return element;
        }

        public void Swap(int index1, int index2)
        {
            CheckIndexes(index1);
            CheckIndexes(index2);

            T tempValue = this.array[index1];
            this.array[index1] = this.array[index2];
            this.array[index2] = tempValue;
        }

        public override string ToString()
        {
            return string.Join("\n", array.Take(this.Count));
        }

        public void Sort()
        {
            for (int i = 0; i < this.Count - 1 ; i++)
            {
                for (int j = i + 1; j < this.Count; j++)
                {
                    if(this.array[i].CompareTo(this.array[j]) > 0)
                    {
                        T tempValue = this.array[i];
                        this.array[i] = this.array[j];
                        this.array[j] = tempValue;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            T[] newArray = new T[this.array.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        private void CheckEmptyList()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }
        }

        private void Shrink()
        {
            T[] newArray = new T[this.array.Length / 3];

            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = array[i];
            }

            this.array = newArray;
        }

        private void CheckIndexes(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new InvalidOperationException("Index was not correct!");
            }
        }
    }
}
