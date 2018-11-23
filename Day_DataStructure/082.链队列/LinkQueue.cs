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

        public LinkQueue()
        {
            top = tail = null;
        }

        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            top = tail = null;
            count = 0;
        }

        public T Dequeue()
        {
            if (top == null)
            {
                Console.WriteLine("is null");
                return default(T);
            }
            T value = top.Data;
            top = top.Next;
            count--;
            return value;
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

        public bool IsEmpty() => count == 0;
        

        public T Peek()
        {
            return top.Data;
        }
    }
}
