using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class DoubleLinkList
    {
        private Node head;
        private int count;

        public DoubleLinkList()
        {
            head = new Node(0,null,null);
            head.PreNode = head;
            head.NextNode = head;
            count = 0;
        }

        public Node GetNode(int index)
        {
            if (index < 0 || index > count)
            {
                Console.WriteLine("索引越界");
                return null;
            }

            if (index < count / 2)
            {
                Node temp = head.NextNode;

                for (int i = 0; i < index; i++)
                    temp = temp.NextNode;

                return temp;
            }

            Node temp_ = head.PreNode;

            index = count - index - 1;

            for (int i = 0; i < index; i++)
                temp_ = temp_.PreNode;

            return temp_;

        }
        public void Append(int index, int value)
        {
            Node temp = null;

            if (index == 0)
            {
                temp = head;
            }
            else
            {
                //index = index - 1;
                if (index < 0)
                    return;
                temp = GetNode(index);
            }

            Node newNode = new Node(value, temp, temp.NextNode);
            temp.NextNode.PreNode = newNode;
            temp.NextNode = newNode;
            count++;
        }
        public void Insert(int index, int value)
        {
            if (index == 0)
            {
                Append(index, value);
                return;
            }
            else
            {
                //index = index - 1;
                if (index < 0)
                    return;
                Node temp = GetNode(index);
                Node newNode = new Node(value, temp.PreNode, temp);
                temp.PreNode.NextNode = newNode;
                temp.PreNode = newNode;
            }
            count++;
        }
        public int GetFirst() => GetNode(0).Data;
        public int GetLast() => GetNode(count - 1).Data;
        public int Get(int index) => GetNode(index).Data;
        public void Del(int index)
        {
            Node temp = GetNode(index);
            temp.PreNode.NextNode = temp.NextNode;
            temp.NextNode.PreNode = temp.PreNode;
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
