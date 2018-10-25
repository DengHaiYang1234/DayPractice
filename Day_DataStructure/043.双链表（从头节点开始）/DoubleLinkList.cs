using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class DoubleLinkList
    {
        Node head;
        int count;
        public DoubleLinkList()
        {
            head = null;
            count = 0;
        }
        public Node GetNode(int index)
        {
            if(index < 0 || index > count)
            {
                Console.WriteLine("GetNode  越界");
                return null;
            }

            //之前
            if(index < count / 2)
            {
                Node temp = head;
                for (int i = 0; i < index; i++)
                    temp = temp.NextNode;
                return temp;
            }

            Node _temp = head;
            int idx = count - index;
            for (int i = 0; i < idx; i++)
                _temp = _temp.PreNode;
            return _temp;
        }
        public int GetFirst() => GetNode(0).Data;
        public int GetLast() => GetNode(count - 1).Data;
        public int GetData(int index) => GetNode(index).Data;
        public void Insert(int index,int value)
        {
            Node temp = null;
            if(index == 0 && head == null)
            {
                head = new Node(value);
                head.NextNode = head;
                head.PreNode = head;
                count++;
                return;
            }
            else if(index == 0 && head != null)
            {
                Node newNode_ = new Node(value, head.PreNode, head);
                head.PreNode.NextNode = newNode_;
                head.PreNode = newNode_;
                head = newNode_;
            }
            else
            {
                temp = GetNode(index);
                Node newNode = new Node(value, temp.PreNode, temp);
                temp.PreNode.NextNode = newNode;
                temp.PreNode = newNode;
            }

            count++;
        }
        public void Append(int index,int value)
        {
            Node temp = null;
            if(index == 0 && head == null)
            {
                head = new Node(value);
                head.NextNode = head;
                head.PreNode = head;
                count++;
                return;
            }
            else if(index == 0 && head != null)
            {
                temp = head;
            }
            else
            {
                temp = GetNode(index);
            }

            Node newNode = new Node(value, temp, temp.NextNode);
            temp.NextNode.PreNode = newNode;
            temp.NextNode = newNode;
            count++;
        }
        public void DeleteNode(int index)
        {
            if(index == 0)
            {
                head.PreNode.NextNode = head.NextNode;
                head.NextNode.PreNode = head.PreNode;
                head = head.NextNode;
            }
            else
            {
                Node temp = GetNode(index);
                temp.PreNode.NextNode = temp.NextNode;
                temp.NextNode.PreNode = temp.PreNode;
            }
            count--;
        }
        public void DeleteFirst() => DeleteNode(0);
        public void DeleteLast() => DeleteNode(count - 1);
        public void ShowAll()
        {
            for(int i = 0;i < count;i++)
            {
                Console.WriteLine("索引：" + i + ",Value =" + GetData(i));
            }
        }
    }
}
