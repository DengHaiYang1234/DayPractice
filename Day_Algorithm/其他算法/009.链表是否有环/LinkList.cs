using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkList<T> : ILickList<T>
    {
        private Node<T> head = null;

        public T this[int index]
        {
            get { return GetNode(index).Data; }
        }

        public int Length
        {
            get
            {
                int count = 0;
                Node<T> temp = head;
                while (temp != null)
                {
                    count++;
                    temp = temp.Next;
                }

                return count;
            }
        }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> temp = head;
                for (int i = 1; i < Length; i++)
                {
                    temp = temp.Next;
                }
                Node<T> iNode = null;
                if (IndexOf(newNode.Data) != -1)
                {
                    iNode = GetNode(IndexOf(newNode.Data));
                }

                Node<T> nextNode = temp.Next;
                temp.Next = newNode;
                
                if (iNode != null)
                {
                    newNode.Next = iNode.Next;
                }
                else
                    newNode.Next = nextNode;
            }
        }

        public void Clear()
        {
            head = null;
        }

        public int GetLength() => Length;

        public Node<T> GetNode(int index)
        {
            int _index = -1;
            Node<T> temp = head;
            while (temp != null)
            {
                _index++;
                if (index == _index)
                {
                    break;
                }

                temp = temp.Next;
            }

            return temp;
        }

        public int IndexOf(T item)
        {
            int index = -1;
            Node<T> temp = head;
            while (temp != null)
            {
                index++;
                if (temp.Data.Equals(item))
                {
                    return index;
                }
                temp = temp.Next;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (head == null && index == 0)
            {
                head = newNode;
            }
            else
            {
                if (index == 0)
                {
                    newNode.Next = head;
                    head = newNode;
                }
                else
                {
                    Node<T> temp = head;
                    for (int i = 1; i < index; i++)
                    {
                        temp = temp.Next;
                    }

                    Node<T> nextNode = temp.Next;
                    temp.Next = newNode;
                    newNode.Next = nextNode;
                }
            }
        }

        public bool IsExist(T item) => IndexOf(item) == -1;
   

        public T Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0 || index > Length)
            {
                Console.WriteLine("Is Null");
                return default(T);
            }

            Node<T> temp = head;

            for (int i = 1; i < index; i++)
            {
                temp = temp.Next;
            }

            T value = temp.Data;

            temp.Next = temp.Next.Next;
            return value;

        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index > Length)
            {
                Console.WriteLine("Is Null");
                return default(T);
            }

            Node<T> temp = head;

            for (int i = 1; i < index; i++)
            {
                temp = temp.Next;
            }

            T value = temp.Data;

            temp.Next = temp.Next.Next;

            return value;
        }

        public Node<T> DetectCycle()
        {
            Node<T> slow = head;
            Node<T> fast = head;
            bool hasCycle = false;

            while (fast.Next != null && fast.Next.Next != null )
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    hasCycle = true;
                    break;
                }
            }

            if (hasCycle)
            {
                Node<T> q = head;
                while (slow != q)
                {
                    slow = slow.Next;
                    q = q.Next;
                }
                return q;
            }
            else
            {
                return null;
            }
        }

        public Node<T> CycleInfo(out int length)
        {
            Node<T> iNode = DetectCycle();
            length = 1;
            Node<T> temp = iNode;
            while (temp.Next != iNode)
            {
                length++;
                temp = temp.Next;
            }

            return iNode;
        }
    }
}
