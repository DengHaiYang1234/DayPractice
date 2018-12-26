using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkStack : ILinkStack
    {
        private Node top;
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
            top = null;
            count = 0;
        }

        public int Peek()
        {
            return top.Data;
        }

        public int Pop()
        {
            int value = -1;
            value = top.Data;
            top = top.Next;
            return value;
        }

        public void Push(int item)
        {
            Node newNode = new Node(item);
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
