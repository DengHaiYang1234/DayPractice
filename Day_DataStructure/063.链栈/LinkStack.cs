using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkStack<T> : ILinkStack<T>
    {
        private Node<T> top;
        private int count;

        public LinkStack()
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
            count = 0;
            top = null;
        }
        

        public bool Contains(T item)
        {
            Node<T> temp = top;
            while (temp != null)
            {
                if (temp.Data.Equals(item))
                {
                    return true;
                }

                temp = temp.Next;
            }
            return false;
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
            Node<T> newItem = new Node<T>(item);
            if (top == null)
            {
                top = newItem;
            }
            else
            {
                newItem.Next = top;
                top = newItem;
            }
            count++;
        }
    }
}
