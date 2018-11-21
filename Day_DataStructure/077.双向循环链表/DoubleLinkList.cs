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
                Console.WriteLine("越界");
                return null;
            }

            Node temp = head;

            if (index < count/2)
            {
                for (int i = 0; i < index; i++)
                    temp = temp.NextNode;
            }
            else
            {
                index = count - index;
                for (int i = 0; i < index; i++)
                    temp = temp.PreNode;
            }

            return temp;
        }

        public int GetFirst() => GetElem(0).Data;
        public int GetLast() => GetElem(count - 1).Data;
        public int Get(int index) => GetElem(index).Data;

        public void Append(int index,int item)
        {
            if (index == 0 && head == null)
            {
                Node headItem = new Node(item, null, null);
                head = headItem;
                head.PreNode = head;
                head.NextNode = head;
            }
            else
            {
                Node iNode = GetElem(index);
                Node newItem = new Node(item,iNode,iNode.NextNode);
                iNode.NextNode.PreNode = newItem;
                iNode.NextNode = newItem;
            }
            count++;
        }


        public void Insert(int index,int item)
        {
            if (index == 0 && head == null)
            {
                Node headItem = new Node(item, null, null);
                head = headItem;
                head.PreNode = head;
                head.NextNode = head;
            }
            else
            {
                Node iNode = GetElem(index);
                Node newItem = new Node(item,iNode.PreNode,iNode);
                iNode.PreNode.NextNode = newItem;
                iNode.PreNode = newItem;
                if (index == 0)
                    head = newItem;
            }
            count++;
        }

        public void Delete(int index)
        {
            Node iNode = GetElem(index);
            if (index == 0)
            {
                head = iNode.NextNode;
                head.PreNode = iNode.PreNode;
                iNode.PreNode.NextNode = head;
            }
            else
            {
                iNode.PreNode.NextNode = iNode.NextNode;
                iNode.NextNode.PreNode = iNode.PreNode;
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
