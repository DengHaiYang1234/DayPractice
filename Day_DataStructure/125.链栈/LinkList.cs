using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LinkList<T> : ILinkList<T>
    {
        private Node<T> top;
        private int count;

        public LinkList()
        {
            top = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Clear()
        {
            top = null;
            count = 0;
        }

        public T Peek()
        {
            return top.Data;
        }

        public T Pop()
        {
            T value = top.Data;
            top = top.Next;
            count--;
            return value;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (top == null)
            {
                top = newNode;
            }
            else
            {
                newNode.Next = top;
                top = newNode;
            }
            count++;
        }
    }
}
