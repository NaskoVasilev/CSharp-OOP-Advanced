using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node tail;
        private Node head;

        public LinkedList()
        {
            this.tail = null;
            this.head = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(T value)
        {
            Node newNode = new Node(value);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = this.tail.Next;
            }

            this.Count++;
        }

        public bool Remove(T value)
        {
            if (this.Count == 0)
            {
                return false;
            }

            if (value.Equals(this.head.Value))
            {
                Node oldNode = this.head;
                this.head = this.head.Next;
                oldNode = null;
            }
            else
            {
                Node targetNode = null;
                Node parentNode = null;
                Node current = this.head;

                while (current.Next != null)
                {
                    if (current.Next.Value.Equals(value))
                    {
                        targetNode = current.Next;
                        parentNode = current;
                        break;
                    }
                    current = current.Next;
                }

                if (targetNode == null)
                {
                    return false;
                }

                parentNode.Next = targetNode.Next;
                targetNode = null;
            }

            this.Count--;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.head;

            while (current != null)
            {
                yield return current.Value;

                current = current.Next;
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
                Value = value;
            }

            public T Value { get; private set; }

            public Node Next { get; set; }
        }
    }
}
