using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class DoubleLinkList<T>
    {
        int count;
        Node<T> head;

        public DoubleLinkList()
        {
            count = 0;
            head = new Node<T>(default(T),null,null);
            head.Prev = head;
            head.Next = head;
        }

        public Node<T> GetNode(int index)
        {
            if(index < 0 || index > count)
            {
                Console.WriteLine("索引越界");
                return null;
            }

            if(index < count / 2)
            {
                Node<T> temp = head.Next;
                for (int i = 0; i < index; i++)
                    temp = temp.Next;
                return temp;
            }

            Node<T> _temp = head.Prev;
            int rIndex = count - index - 1;
            for (int i = 0; i < rIndex; i++)
                _temp = _temp.Prev;
            return _temp;
        }

        public T GetFirst() => GetNode(0).Data;
        public T GetLast() => GetNode(count - 1).Data;
        public T Get(int i) => GetNode(i).Data;

        //index之后
        public void Append(int index,T item)
        {
            Node<T> iNode;
            if(index == 0)
            {
                iNode = head;
            }
            else
            {
                index = index - 1;//获取当前要插入索引的前一个索引
                if(index < 0)
                {
                    Console.WriteLine("越界");
                    return;
                }
                iNode = GetNode(index);
            }

            Node<T> newItem = new Node<T>(item, iNode, iNode.Next);
            iNode.Next.Prev = newItem;
            iNode.Next = newItem;
            count++;
        }

        //索引之前
        public void Insert(int index,T item)
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
                    Console.WriteLine("越界");
                    return;
                }
                iNode = GetNode(index);
            }
            Node<T> newItem = new Node<T>(item, iNode.Prev, iNode);
            iNode.Prev.Next = newItem;
            iNode.Prev = newItem;
            count++;
        }

        public void Del(int index)
        {
            if (index < 0 || index > count)
            {
                Console.WriteLine("越界");
                return;
            }

            Node<T> iNode = GetNode(index);
            iNode.Prev.Next = iNode.Next;
            iNode.Next.Prev = iNode.Prev;
            count--;
        }


        public void DelFirst() => Del(0);
        public void DelLast() => Del(count - 1);

        public void ShowAll()
        {
            Console.WriteLine("----------------Start--------------");
            for(int i = 0; i< count;i++)
            {
                Console.WriteLine("<" + i + ">:" + Get(i));
            }
            Console.WriteLine("----------------End-----------------");
        }
       
    }
}
