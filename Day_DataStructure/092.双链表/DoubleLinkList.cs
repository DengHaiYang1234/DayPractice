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
            if (index > count || index < 0)
            {
                Console.WriteLine("GetNode is Called .But index > count || index < 0");
                return null;
            }

            Node temp = head;

            if (index < count/2)
            {
                for (int i = 0; i < index; i++)
                    temp = temp.Next;
            }
            else
            {
                index = count - index;
                for (int i = 0; i < index; i++)
                    temp = temp.Pre;
            }

            return temp;


        }

        public int GetFirst() => GetElem(0).Data;
        public int GetLast() => GetElem(count - 1).Data;
        public int Get(int index) => GetElem(index).Data;

        public void Append(int index,int value)
        {
            if (index == 0 && head == null)
            {
                head = new Node(value, null, null);
                head.Pre = head;
                head.Next = head;
            }
            else
            {
                Node iNode = GetElem(index);
                Node temp = new Node(value, iNode, iNode.Next);
                iNode.Next.Pre = temp;
                iNode.Next = temp;
            }
            count++;
        }

        public void Insert(int index,int value)
        {
            if (index == 0 && head == null)
            {
                head = new Node(value, null, null);
                head.Pre = head;
                head.Next = head;
            }
            else
            {
                Node iNode = GetElem(index);
                Node temp = new Node(value, iNode.Pre, iNode);
                iNode.Pre.Next = temp;
                iNode.Pre = temp;
                if (index == 0)
                {
                    head = temp;
                }
            }
            count++;
        }

        public void Delete(int index)
        {
            Node iNode = GetElem(index);
            if (index == 0)
            {
                iNode.Next.Pre = iNode.Pre;
                iNode = iNode.Next;
                head = iNode;
            }
            else
            {
                iNode.Pre.Next = iNode.Next;
                iNode.Next.Pre = iNode.Pre;
                count--;
            }


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
