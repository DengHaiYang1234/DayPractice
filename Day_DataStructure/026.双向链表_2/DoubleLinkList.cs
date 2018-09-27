using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class DoubleLinkList<T>
    {
        Node<T> head;
        int size;

        public DoubleLinkList()
        {
            head = new Node<T>(default(T), null, null);
            head.Prev = head;
            head.Next = head;
            size = 0;
        }

        public Node<T> GetNode(int index)
        {
            if(index < 0 || index > size)
            {
                Console.WriteLine("越界");
                return null;
            }

            if(index < size / 2)
            {
                Node<T> temp = head.Next;
                for (int i = 0; i < index; i++)
                    temp = temp.Next;
                return temp;
            }

            Node<T> _temp = head.Prev;
            int rIndex = size - index - 1;
            for(int i = 0;i < rIndex;i++)
            {
                _temp = _temp.Prev;
            }
            return _temp;
        }

        public T GetFirst() => GetNode(0).Data;
        public T GetLast() => GetNode(size - 1).Data;

        public T Get(int index) => GetNode(index).Data;

        public void Append(int index,T item)
        {
            Node<T> iNode;
            if(index == 0)
            {
                iNode = head;
            }
            else
            {
                index = index - 1;
                if(index < 0)
                {
                    Console.WriteLine("越界 Append");
                    return;
                }
                iNode = GetNode(index);
            }
            

            Node<T> newItem = new Node<T>(item,iNode,iNode.Next);
            iNode.Next.Prev = newItem;
            iNode.Next = newItem;
            size++;
        }

        public void Insert(int index,T item)
        {
            if(index == 0)
            {
                Append(index, item);
            }
            else
            {
                index = index - 1;
                if(index < 0)
                {
                    Console.WriteLine("Insert 错误");
                    return;
                }
                Node<T> iNode = GetNode(index);
                Node<T> newItem = new Node<T>(item, iNode.Prev, iNode);
                iNode.Prev.Next = newItem;
                iNode.Prev = newItem;
                size++;
            }
        }

        public void Add(T item)
        {
            Append(size, item);
        }

        public void Del(int index)
        {
            if (index < 0 || index > size)
            {
                Console.WriteLine("越界");
                return;
            }

            Node<T> temp = GetNode(index);
            temp.Prev.Next = temp.Next;
            temp.Next.Prev = temp.Prev;
        }

        public void DelFirst() => Del(0);
        public void DelLast() => Del(size - 1);

        public void ShowAll()
        {
            Console.WriteLine("---------Start--------");
            for(int i = 0;i < size;i++)
            {
                Console.WriteLine("<" + i + ">:" + Get(i));
            }
            Console.WriteLine("---------End--------");
        }
    }
}
