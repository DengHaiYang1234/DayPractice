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
        private Node minNode;

        public int Count
        {
            get { return count; }
        }

        public LinkStack()
        {
            top = null;
            minNode = null;
            count = 0;
        }

        public int Peek()
        {
            if (top == null)
            {
                Console.WriteLine("越界");
                return -1;
            }

            return top.Data;
        }

        public int Pop()
        {
            if (top == null)
            {
                Console.WriteLine("越界");
                return -1;
            }
            int value = top.Data;
            top = top.Next;
            minNode = minNode.Next;
            count--;
            return value;
        }

        public void Push(int item)
        {
            Node newItem = new Node(item);
            if (top == null)
            {
                top = newItem;
            }
            else
            {
                newItem.Next = top;
                top = newItem;
            }
            SetMin(item);
            count++;
        }

        public void Clear()
        {
            top = null;
        }

        public void SetMin(int item)
        {
            Node newItem = new Node(item);
            if (minNode == null)
            {
                minNode = newItem;
            }
            else
            {
                if (item < minNode.Data)
                {
                    newItem.Next = minNode;
                    minNode = newItem;
                }
                else
                {
                    Node newItem_ = new Node(top.Data);
                    newItem_.Next = minNode;
                    minNode = newItem_;
                }
            }
        }

        public int GetMin()
        {
            if (minNode == null)
            {
                Console.WriteLine("越界");
                return -1;
            }
            return minNode.Data;
        }
    }
}
