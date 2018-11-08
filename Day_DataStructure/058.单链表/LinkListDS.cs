using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class LinkListDS<T> : ILinkListDS<T>
    {

        private Node<T> head;


        public LinkListDS()
        {
            head = null;

        }

        public T this[int index]
        {
            get { return GetItem(index); }
        }

        public int Length
        {
            get { return GetLength(); }
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
                    temp = temp.Next;

                temp.Next = newNode;
            }
        }

        public void Clear() => head = null;
        
        public int GetLength()
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

        public int IndexOf(T item)
        {
            if (head == null)
            {
                return -1;
            }
            int index = -1;
            Node<T> temp = head;

            while (temp != null)
            {
                index++;

                if (temp.Data.Equals(item))
                    break;

                temp = temp.Next;
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            Node<T> newNode = new Node<T>(item);

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

                Node<T> preNode = temp;
                Node<T> nextNode = temp.Next;
                preNode.Next = newNode;
                newNode.Next = nextNode;
            }
        }

        public bool IsExist(T item) => IndexOf(item) == -1;
        
        public T Remove(T item)
        {
            int index = IndexOf(item);
            T value = default(T);
            if (index != -1)
            {
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

                    value = temp.Next.Data;

                    Node<T> preNode = temp;
                    Node<T> nextNode = temp.Next.Next;
                    preNode.Next = nextNode;
                }
            }

            return value;
        }

        public T RemoveAt(int index)
        {
            T value = default(T);
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
                value = temp.Next.Data;
                temp.Next = temp.Next.Next;
            }

            return value;
        }

        public T GetItem(int index)
        {
            Node<T> temp = head;
            T value = default(T);
            int gIndex = -1;

            while (temp != null)
            {
                gIndex++;
                if (gIndex == index)
                {
                    value = temp.Data;
                    break;
                }
                temp = temp.Next;
            }

            return value;

        }
    }
}
