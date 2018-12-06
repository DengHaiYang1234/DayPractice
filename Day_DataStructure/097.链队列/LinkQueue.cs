using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkQueue<T> : ILinkQueue<T>
    {
        private Node<T> rear; //尾
        private Node<T> front; //头
        private int count;

        public LinkQueue()
        {
            rear = null;
            front = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            rear = front = null;
            count = 0;
        }

        public T Dequeue()
        {
            T value = front.Data;
            front = front.Next;
            count--;
            return value;
        }

        public void Enqueue(T item)
        {
            Node<T> newItem = new Node<T>(item);
            if (rear == null)
            {
                front = newItem;
                rear = newItem;
            }
            else
            {
                rear.Next = newItem;
                rear = newItem;
            }
            count++;
        }

        public bool IsEmpty() => count == 0;
        

        public T Peek()
        {
            return front.Data;
        }
    }
}
