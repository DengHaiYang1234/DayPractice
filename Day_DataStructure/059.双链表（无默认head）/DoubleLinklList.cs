using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class DoubleLinklList
    {
        private Node head;
        private int count;
        public DoubleLinklList()
        {
            head = null;
            count = 0;
        }
        public Node GetNode(int index)
        {
            if (index < 0 || index > count)
            {
                Console.WriteLine("索引越界");
                return null;
            }

            if (index < count /2)
            {
                Node temp = head;

                for (int i = 0; i < index; i++)
                    temp = temp.NextNode;

                return temp;
            }

            Node temp_ = head;

            index = count - index;

            for (int i = 0; i < index; i++)
                temp_ = temp_.PreNode;

            return temp_;

        }
        public void Append(int index,int value)
        {
            if (index == 0 && head == null)
            {
                head = new Node(value,null,null);
                head.PreNode = head;
                head.NextNode = head;
            }
            else
            {
                if (index < 0)
                    return;
                Node temp = GetNode(index);
                Node newNode = new Node(value, temp, temp.NextNode);
                temp.NextNode.PreNode = newNode;
                temp.NextNode = newNode;
            }
            count++;
        }
        public void Insert(int index,int value)
        {
            if (index == 0 && head == null)
            {
                head = new Node(value, null, null);
                head.PreNode = head;
                head.NextNode = head;
            }
            else
            {
                if (index < 0)
                    return;
                Node temp = GetNode(index);
                Node newNode = new Node(value, temp.PreNode, temp);
                temp.PreNode.NextNode = newNode;
                temp.PreNode = newNode;
                if (index == 0)
                {
                    head = newNode;
                }
            }
            count++;
        }
        public int GetFirst() => GetNode(0).Data;
        public int GetLast() => GetNode(count - 1).Data;
        public int Get(int index) => GetNode(index).Data;
        public void Del(int index)
        {
            if (index == 0)
            {
                Node _temp = head;
                head = head.NextNode;
                head.PreNode = _temp.PreNode;
                _temp.PreNode.NextNode = head;
            }
            else
            {
                Node temp = GetNode(index);
                temp.PreNode.NextNode = temp.NextNode;
                temp.NextNode.PreNode = temp.PreNode;
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
