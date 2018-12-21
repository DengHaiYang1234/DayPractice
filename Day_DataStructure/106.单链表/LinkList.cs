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
            get { return GetNodeByIndex(index).Data; }
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
            if (index > Length || index < 0)
            {
                Console.WriteLine("Err");
                return;
            }
            else
            {
                Node<T> newNode = new Node<T>(item);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node<T> temp = head;

                    for (int i = 1; i < index; i++)
                    {
                        temp = temp.Next;
                    }

                    Node<T> nextTemp = temp.Next;
                    temp.Next = newNode;
                    newNode.Next = nextTemp;
                }
            }
        }

        public bool IsExist(T item) => IndexOf(item) == -1;
        

        public T Remove(T item)
        {
            int index = IndexOf(item);
            if (index > Length || index < 0)
            {
                Console.WriteLine("Err");
                return default(T);
            }

            T value = GetNodeByIndex(index).Data;

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node<T> temp = head;
                for (int i = 1; i < index; i++)
                {
                    temp = temp.Next;
                }

                temp.Next = temp.Next.Next;
            }

            return value;
        }

        public Node<T> GetNodeByIndex(int index)
        {
            Node<T> temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.Next;
            }

            return temp;
        }

        public T RemoveAt(int index)
        {
            if (index > Length || index < 0)
            {
                Console.WriteLine("Err");
                return default(T);
            }

            T value = GetNodeByIndex(index).Data;

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node<T> temp = head;
                for (int i = 1; i < index; i++)
                {
                    temp = temp.Next;
                }

                temp.Next = temp.Next.Next;
            }

            return value;
        }
    }
}
