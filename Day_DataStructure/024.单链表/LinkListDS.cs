using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class LinkListDS<T> : ILinkListDS<T>
    {
        Node<T> head;

        public LinkListDS()
        {
            head = null;
        }

        public int Length
        {
            get
            {
                return GetLength();
            }
        }

        public T this[int index]
        {
            get
            {
                Node<T> temp = head;
                T value = default(T);
                int count = Length;
                for(int i = 0; i< count;i++)
                {
                    if(index == i)
                    {
                        value = temp.Data;
                        break;
                    }
                    temp = temp.Next;
                }
                return value;
            }
        }

        public void Add(T item)
        {
            Node<T> newItem = new Node<T>(item);
            if(head == null)
            {
                head = newItem;
            }
            else
            {
                Node<T> temp = head;
                while(temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newItem;
            }
        }

        public void Clear() => head = null;
        

        public int GetLength()
        {
            if(head == null)
            {
                return 0;
            }
            int count = 1;

            Node<T> temp = head;
            while(temp.Next != null)
            {
                temp = temp.Next;
                count++;
            }
            return count;
        }

        public int IndexOf(T item)
        {
            Node<T> temp = head;
            int count = Length;
            int index = -1;
            for(int i = 0; i < count; i++)
            {
                if(temp.Data.Equals(item))
                {
                    index = i;
                    break;
                }
                temp = temp.Next;
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            int count = Length;
            if(index > count || index < 0)
            {
                Console.WriteLine("越界");
                return;
            }

            Node<T> newItem = new Node<T>(item);

            if(index == 0)
            {
                newItem.Next = head;
                head = newItem;
                return;
            }

            Node<T> temp = head;
            for(int i = 1; i< index;i++)
            {
                temp = temp.Next;
            }

            Node<T> leftNode = temp;
            Node<T> rightNode = temp.Next;
            leftNode.Next = newItem;
            newItem.Next = rightNode;
        }

        public bool IsExist(T item) => head == null;
        

        public T Remove(T item)
        {
            T value = default(T);
            if(head == null)
            {
                Console.WriteLine("链表为空");
                return value;
            }

            int index = IndexOf(item);

            if(index == -1)
            {
                Console.WriteLine("没有找到");
                return value;
            }

            Node<T> temp = head;
            
            if (index == 0)
            {
                value = temp.Data;
                temp = temp.Next;
            }
            else
            {
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
            int count = Length;
            if (head == null || index < 0 || index > count)
            {
                Console.WriteLine("链表为空或索引越界");
                return value;
            }

            Node<T> temp = head;
            if (index == 0)
            {
                value = temp.Data;
                temp = temp.Next;
            }
            else
            {
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
