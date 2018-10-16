using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class TwoForkedTree
    {
        Node tree;

        public TwoForkedTree()
        {
            tree = new Node("A");
        }

        public Node CreatFakeTree()
        {
            tree.Left = new Node()
            {
                Data = "B",
                Left = new Node() { Data = "D", Left = new Node() { Data = "G" } },
                Right = new Node() { Data = "E", Right = new Node() { Data = "H" } }
            };

            tree.Right = new Node() { Data = "C", Right = new Node() { Data = "F" } };
            return tree;
        }

        //先序遍历可用作与目录结构的显示
        public void ProSort(Node tree)
        {
            if (tree == null)
                return;
            Console.WriteLine(tree.Data);
            ProSort(tree.Left);
            ProSort(tree.Right);
        }
        //中序遍历可以用来做表达式树
        public void MidSort(Node tree)
        {
            if (tree == null)
                return;
            MidSort(tree.Left);
            Console.WriteLine(tree.Data);
            MidSort(tree.Right);
        }

        //后序遍历可做用于目录大小的计算
        public void LastSort(Node tree)
        {
            if (tree == null)
                return;
            LastSort(tree.Left);
            LastSort(tree.Right);
            Console.WriteLine(tree.Data);
        }

        public void ProSortByNoram(Node tree)
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp = tree;
            while(temp != null || stack.Count != 0)
            {
                //遍历左子树
                while(temp != null)
                {
                    Console.WriteLine(temp.Data);
                    stack.Push(temp);
                    temp = temp.Left;
                }

                //查找每个节点的右子树
                if(stack.Count != 0)
                {
                    temp = stack.Pop();
                    temp = temp.Right;
                }
            }
        }


        public void MidSortByNoram(Node tree)
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp = tree;
            while(temp != null || stack.Count != 0)
            {
                while(temp != null)
                {
                    stack.Push(temp);
                    temp = temp.Left;
                }

                if(stack.Count != 0)
                {
                    temp = stack.Pop();
                    Console.WriteLine(temp.Data);
                    temp = temp.Right;
                }
            }
        }
        
        public void LastSortByNoram(Node tree)
        {
            Stack<Node> stack = new Stack<Node>();
            Node currNode = null;
            Node preNode = null;
            stack.Push(tree);
            while(stack.Count != 0)
            {
                currNode = stack.Peek();
                if((currNode.Left == null && currNode.Right == null) || (preNode != null && (preNode == currNode.Left || preNode == currNode.Right)))
                {
                    Console.WriteLine(currNode.Data);
                    stack.Pop();
                    preNode = currNode;
                }
                else
                {
                    if (currNode.Right != null)
                        stack.Push(currNode.Right);
                    if (currNode.Left != null)
                        stack.Push(currNode.Left);
                }
            }
        }
    }
}
