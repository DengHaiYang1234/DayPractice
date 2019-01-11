using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkList<T> : ILinkList<T>
    {
        private Node<T> head;

        public LinkList()
        {
            head = null;
        }

        public T this[int index]
        {
            get { return GetNode(index).Data; }
        }

        public Node<T> GetNode(int index)
        {
            int _index = -1;
            Node<T> temp = head;
            while (temp != null)
            {
                _index++;
                if (index == _index)
                    break;
                temp = temp.Next;
            }

            return temp;
        }

        public int Length
        {
            get
            {
                Node<T> temp = head;
                int count = 0;
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
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = newNode;
            }
        }

        public void Clear() => head = null;

        public int GetLength() => Length;
        

        public int IndexOf(T item)
        {
            int index = -1;
            Node<T> temp = head;
            while (temp != null)
            {
                index++;
                if (temp.Data.Equals(item))
                {
                    break;
                }
                temp = temp.Next;
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (head == null)
            {
                head = newNode;
            }
            else if (index == 1 && head != null)
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

        public bool IsExist(T item) => IndexOf(item) == -1;
        

        public T Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                Console.WriteLine("is Null");
                return default(T);
            }
            T value;

            if (index == 0)
            {
                value = head.Data;
                head = head.Next;
            }
            else
            {
                Node<T> temp = head;

                for (int i = 1; i < index; i++)
                {
                    temp = temp.Next;
                }
                value = temp.Next.Data;
                temp.Next = temp.Next.Next;
            }

            return value;
        }

        public T RemoveAt(int index)
        {
            if (index == -1)
            {
                Console.WriteLine("is Null");
                return default(T);
            }
            T value;

            if (index == 0)
            {
                value = head.Data;
                head = head.Next;
            }
            else
            {
                Node<T> temp = head;

                for (int i = 1; i < index; i++)
                {
                    temp = temp.Next;
                }
                value = temp.Next.Data;
                temp.Next = temp.Next.Next;
            }

            return value;
        }
    }
}
