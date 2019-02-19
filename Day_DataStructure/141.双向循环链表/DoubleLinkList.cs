using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class DoubleLinkList
    {
        private Node head;
        private int count;

        public DoubleLinkList()
        {
            head = null;
            count = 0;
        }

        public Node GetElem(int index)
        {
            if (index < 0 || index > count)
            {
                Console.WriteLine("元素未找到");
                return null;
            }

            int mid = count/2;

            if (index < mid)
            {
                Node temp = head;

                for (int i = 0; i < index; i++)
                    temp = temp.Next;

                return temp;
            }
            else
            {
                Node _temp = head;
                index = count - index;
                for (int i = 0; i < index; i++)
                    _temp = _temp.Pre;

                return _temp;
            }
        }

        public int GetFirst() => GetElem(0).Data;
        public int GetLast() => GetElem(count - 1).Data;
        public int Get(int index) => GetElem(index).Data;

        public void Append(int index,int value)
        {
            if (head == null)
            {
                head = new Node(value, null, null);
                head.Pre = head;
                head.Next = head;
            }
            else
            {
                Node iNode = GetElem(index);
                Node newNode = new Node(value,iNode,iNode.Next);
                iNode.Next.Pre = newNode;
                iNode.Next = newNode;
            }
            count++;
        }

        public void Insert(int index,int value)
        {
            if (head == null)
            {
                head = new Node(value, null, null);
                head.Pre = head;
                head.Next = head;
            }
            else
            {
                Node iNode = GetElem(index);
                Node newNode = new Node(value, iNode.Pre, iNode);
                iNode.Pre.Next = newNode;
                iNode.Pre = newNode;
                if (index == 0)
                {
                    head = newNode;
                }
            }
            count++;
        }

        public void Delete(int index)
        {
            Node iNode = GetElem(index);
            iNode.Pre.Next = iNode.Next;
            iNode.Next.Pre = iNode.Pre;

            if (index == 0)
            {
                head = head.Next;
            }
            count--;
        }

        public void DelFirst() => Delete(0);
        public void DelLast() => Delete(count - 1);

        public void ShowAll()
        {
            Console.WriteLine("---------Start--------");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("<" + i + ">:" + Get(i));
            }
            Console.WriteLine("---------End--------");
        }
    }
}
