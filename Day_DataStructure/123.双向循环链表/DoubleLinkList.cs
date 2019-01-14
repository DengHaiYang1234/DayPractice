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
            if (index > count || index < 0 || count == 0)
            {
                Console.WriteLine("Is Null");
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

            Node postNode = head;

            int _index = count - index;
            for (int i = 0; i < _index; i++)
            {
                postNode = postNode.Pre;
            }

            return postNode;
        }

        public int GetFirst() => GetElem(0).Data;
        public int GetLast() => GetElem(count - 1).Data;
        public int Get(int index) => GetElem(index).Data;

        public void Append(int index, int value)
        {
            if (head == null)
            {
                head = new Node(value, null, null);
                head.Next = head;
                head.Pre = head;
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
                head.Next = head;
                head.Pre = head;
            }
            else
            {
                if (index < 0 || index > count)
                {
                    Console.WriteLine(" index is outRange ");
                    return;
                }

                Node iNode = GetElem(index);
                Node newNode = new Node(value,iNode.Pre,iNode);
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
            if (index == 0)
            {
                head.Next.Pre = head.Pre;
                head.Pre.Next = head.Next;
                head = head.Next;
            }
            else
            {
                Node iNode = GetElem(index);
                iNode.Pre.Next = iNode.Next;
                iNode.Next.Pre = iNode.Pre;
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
