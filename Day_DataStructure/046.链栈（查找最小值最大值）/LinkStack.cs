using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkStack : ILinkStack
    {
        Node head;
        int count;

        Node min;
        Node max;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public LinkStack()
        {
            head = null;
            count = 0;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public void Push(int item)
        {
            Node newNode = new Node(item);
            if(head == null)
            {
                head = newNode;
                min = newNode;
                max = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;

                SetMin(item);
                SetMax(item);
            }
            count++;
        }

        public int Pop()
        {
            int value = head.Data;
            head = head.Next;
            min = min.Next;
            max = max.Next;
            count--;
            return value;
        }

        public int Peek()
        {
            return head.Data;
        }

        public void SetMin(int item)
        {
            if (item < min.Data)
            {
                Node minNode = new Node(item);
                minNode.Next = min;
                min = minNode;
            }
            else
            {
                Node minNode = new Node(min.Data);
                minNode.Next = min;
                min = minNode;
            }
        }

        public void SetMax(int item)
        {
            if (item > max.Data)
            {
                Node maxNode = new Node(item);
                maxNode.Next = max;
                max = maxNode;
            }
            else
            {
                Node maxNode = new Node(max.Data);
                maxNode.Next = max;
                max = maxNode;
            }
        }

        public int GetMin()
        {
            return min.Data;
        }

        public int GetMax()
        {
            return max.Data;
        }
    }
}
