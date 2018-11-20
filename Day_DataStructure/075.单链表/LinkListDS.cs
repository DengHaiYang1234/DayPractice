using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkListDS<T> : ILinkListDS<T>
    {
        private Node<T> head;

        public LinkListDS()
        {
            head = null;
        }


        public int Length
        {
            get { return GetLength(); }
        }

        public T this[int index]
        {
            get
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

                return temp.Data;
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
            if (head == null)
            {
                head = newNode;
            }
            else if (index == 0 && head != null)
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
                Node<T> postNode = temp.Next;
                preNode.Next = newNode;
                newNode.Next = postNode;
            }
        }

        public bool IsExist(T item) => IndexOf(item) == -1;
        

        public T Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                Console.WriteLine("null");
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
            Node<T> temp = head;
            for (int i = 1; i < index; i++)
            {
                temp = temp.Next;
            }
            T value = temp.Data;
            temp.Next = temp.Next.Next;
            return value;
        }
    }
}
