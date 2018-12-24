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
                Console.WriteLine("Not Find");
                return null;
            }



            if (index < count/2)
            {
                Node temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Next;
                }
                return temp;
            }

            Node temp_ = head;
            int preIndex = count - index;
            for (int i = 0; i < preIndex; i++)
            {
                temp_ = temp_.Pre;
            }

            return temp_;
        }

        public int GetFirst() => GetElem(0).Data;
        public int GetLast() => GetElem(count - 1).Data;
        public int Get(int index) => GetElem(index).Data;


        public void Append(int index,int value)
        {
            if (index == 0 && head == null)
            {
                Node newNode = new Node(value,null,null);
                head = newNode;
                head.Pre = head;
                head.Next = head;
            }
            else
            {
                Node iNode = GetElem(index);
                Node _newNode = new Node(value, iNode, iNode.Next);
                iNode.Next.Pre = _newNode;
                iNode.Next = _newNode;
            }

            count++;
        }

        public void Insert(int index,int value)
        {
            if (index == 0 && head == null)
            {
                Node _newNode = new Node(value, null, null);
                head = _newNode;
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

        public void Del(int index)
        {
            Node iNode = GetElem(index);
            iNode.Pre.Next = iNode.Next;
            iNode.Next.Pre = iNode.Pre;
            if (index == 0)
            {
                head = iNode;
            }
            count--;
        }

        public void DelFirst() => Del(0);
        public void DelLast() => Del(count - 1);

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
