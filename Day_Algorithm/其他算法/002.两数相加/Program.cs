using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。

如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。

您可以假设除了数字 0 之外，这两个数都不会以 0 开头。

示例：

输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
输出：7 -> 0 -> 8
原因：342 + 465 = 807

*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int num_1 = 1;
            int num_2 = 9999;

            Node node1 = AddNumber(num_1);
            Node node2 = AddNumber(num_2);

            Node sum = AddTwoNumbers(node1, node2);
            while (sum != null)
            {
                Console.WriteLine(sum.Data);
                sum = sum.Next;
            }
        }

        static Node AddNumber(int number)
        {
            Node listNode = null;
            Node currNode = null;
            string str = number.ToString();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Node newNode = new Node(int.Parse(str[i].ToString()));
                if (listNode == null)
                {
                    listNode = newNode;
                    currNode = newNode;
                }
                else
                {
                    currNode.Next = newNode;
                    currNode = newNode;
                }
            }

            return listNode;
        }

        static Node AddTwoNumbers(Node node_1,Node node_2)
        {
            int node1Len = GetListNodeCount(node_1);
            int node2Len = GetListNodeCount(node_2);
            int len = node1Len > node2Len ? node1Len : node2Len;
            Node sumListNode = null;
            Node currNode = null;
            double enterNum = 0;
            for (int i = 0; i < len; i++)
            {
                int sum = 0;
                int remainder = 0;

                if (node_1 != null)
                {
                   sum = node_1.Data;
                   node_1 = node_1.Next;
                }

                if (node_2 != null)
                {
                    sum += node_2.Data;
                    node_2 = node_2.Next;
                }

                if (enterNum > 0)
                {
                    sum += (int)enterNum;
                    enterNum = 0;
                }

                remainder = sum % 10;

                Node newNode = new Node(remainder);

                if (sumListNode == null)
                {
                    sumListNode = newNode;
                    currNode = newNode;
                }
                else
                {
                    currNode.Next = newNode;
                    currNode = newNode;
                }

                if (sum > 9)
                {
                    enterNum = Math.Floor((float)sum / 10);
                    if(node_1 == null && node_2 == null)
                        len = len + 1;

                }
            }

            return sumListNode;
        }


        static int GetListNodeCount(Node node)
        {
            int index = 0;
            while (node != null)
            {
                index++;
                node = node.Next;
            }

            return index;
        }
    }
}
