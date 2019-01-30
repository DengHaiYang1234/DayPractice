using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

给定一个链表，旋转链表，将链表每个节点向右移动 k 个位置，其中 k 是非负数。

示例 1:

输入: 1->2->3->4->5->NULL, k = 2
输出: 4->5->1->2->3->NULL
解释:
向右旋转 1 步: 5->1->2->3->4->NULL
向右旋转 2 步: 4->5->1->2->3->NULL
示例 2:

输入: 0->1->2->NULL, k = 4
输出: 2->0->1->NULL
解释:
向右旋转 1 步: 2->0->1->NULL
向右旋转 2 步: 1->2->0->NULL
向右旋转 3 步: 0->1->2->NULL
向右旋转 4 步: 2->0->1->NULL

*/
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(0);
            Node node_2 = new Node(1);
            Node node_3 = new Node(2);
            //Node node_4 = new Node(4);
            //Node node_5 = new Node(5);
            head.Append(node_2);
            node_2.Append(node_3);
            //node_3.Append(node_4);
            //node_4.Append(node_5);
            head =  RotateRight(head, 4);

            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine("temp:" + temp.Data);
                temp = temp.Next;
            }
        }

        private static Node RotateRight(Node head, int k)
        {
            int count = GetLength(head);
            while (k > 0)
            {
                Node temp = head;

                Node pre = null;

                Node lastNode = null;

                for (int i = 1; i < count - 1; i++)
                {
                    temp = temp.Next;
                }

                pre = temp;
                lastNode = temp.Next;
                temp.Next = null;

                lastNode.Next = head;
                head = lastNode;
                k--;
            }

            return head;
        }

        private static int GetLength(Node head)
        {
            int count = 0;
            Node temp = head;
            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }
            return count;
        }
    }
}
