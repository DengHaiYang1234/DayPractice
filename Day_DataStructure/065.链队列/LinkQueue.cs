using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkQueue<T> : ILinkQueue<T>
    {
        private Node<T> top;
        private Node<T> tail;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public LinkQueue()
        {
            top = null;
            tail = null;
            count = 0;
        }

        public void Clear()
        {
            top = tail = null;
            count = 0;
        }

        public void Enqueue(T item)
        {
            Node<T> newItem = new Node<T>(item);
            if (tail == null)
            {
                tail = newItem;
                top = newItem;
            }
            else
            {
                tail.Next = newItem;
                tail = newItem;
            }
            count++;
        }

        public T Dequeue()
        {
            T value = top.Data;
            top = top.Next;
            count--;
            return value;
        }

        public T Peek()
        {
            return top.Data;
        }

        public bool IsEmpty() => count == 0;

    }
}
