using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private Node top;

        public CustomStack()
        {
            this.top = null;
            this.Count = 0;
        }

        public CustomStack(IEnumerable<T> elements) : this()
        {
            foreach (T element in elements)
            {
                this.Push(element);
            }
        }

        public int Count { get; private set; }

        public void Push(T value)
        {
            Node newNode = new Node(value);

            if (this.Count == 0)
            {
                this.top = newNode;
            }
            else
            {
                newNode.Previous = this.top;
                this.top = newNode;
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            Node currentNode = this.top;
            this.top = this.top.Previous;
            T value = currentNode.Value;
            currentNode = null;

            this.Count--;
            return value;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.top;

            while (current != null)
            {
                yield return current.Value;

                current = current.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public Node Previous { get; set; }
        }
    }
}
