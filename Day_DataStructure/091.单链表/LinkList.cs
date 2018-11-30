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

        public int Length
        {
            get { return GetLength(); }
        }

        public T this[int index]
        {
            get { return GetNode(index).Data; }
        }


        public Node<T> GetNode(int index)
        {
            int _id = -1;

            Node<T> temp = head;

            while (temp != null)
            {
                _id++;
                if (_id == index)
                {
                    break;
                }
                temp = temp.Next;
            }

            return temp;
        }

        public void Add(T item)
        {
            Node<T> newItem = new Node<T>(item);
            if (head == null)
                head = newItem;
            else
            {
                Node<T> temp = head;
                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = newItem;
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
            if (index < 0 || index > Length)
            {
                Console.WriteLine("越界");
                return;
            }

            Node<T> newItem = new Node<T>(item);
            if (head == null && index == 0)
            {
                head = newItem;
            }
            else if (index == 0 && head != null)
            {
                newItem.Next = head;
                head = newItem;
            }
            else
            {
                Node<T> temp = head;
                for (int i = 1; i < index; i++)
                {
                    temp = temp.Next;
                }
                Node<T> nextItem = temp.Next;
                temp.Next = newItem;
                newItem.Next = nextItem;
            }
        }

        public bool IsExist(T item) => IndexOf(item) == -1;
        
        public T Remove(T item)
        {
            int index = IndexOf(item);
            T value = default(T);
            if (index == -1)
            {
                Console.WriteLine("不存在");
                return value;
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
            T value = default(T);
            Node<T> temp = head;
            for (int i = 1; i < index; i++)
            {
                temp = temp.Next;
            }

            value = temp.Next.Data;

            temp.Next = temp.Next.Next;

            return value;
        }
    }
}
