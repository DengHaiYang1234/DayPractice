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

        public void Clear() => top = null;
        

        public int Peek()
        {
            return top.Data;
        }

        public int Pop()
        {
            int value = top.Data;
            top = top.Next;
            count--;
            return value;
        }

        public void Push(int item)
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
