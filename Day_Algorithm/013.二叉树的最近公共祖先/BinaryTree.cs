using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。

百度百科中最近公共祖先的定义为：“对于有根树 T 的两个结点 p、q，最近公共祖先表示为一个结点 x，满足 x 是 p、q 的祖先且 x 的深度尽可能大（一个节点也可以是它自己的祖先）。”
示例 1:

输入: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
输出: 3
解释: 节点 5 和节点 1 的最近公共祖先是节点 3。
示例 2:

输入: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
输出: 5
解释: 节点 5 和节点 4 的最近公共祖先是节点 5。因为根据定义最近公共祖先节点可以为节点本身。
 

说明:

所有节点的值都是唯一的。
p、q 为不同节点且均存在于给定的二叉树中。

*/
namespace ConsoleApplication1
{
    public class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void Insert(int value)
        {
            Node current = root;
            Node parent = null;
            Node newNode = new Node(value);

            if (root == null)
            {
                root = newNode;
                return;
            }

            while (true)
            {
                parent = current;
                if (value < current.Data) //左边
                {
                    current = current.Left;
                    if (current == null)
                    {
                        parent.Left = newNode;
                        break;
                    }
                }
                else
                {
                    current = current.Right;
                    if (current == null)
                    {
                        parent.Right = newNode;
                        break;
                    }

                }
            }
        }

        public void PreSort(Node root)
        {
            if (root == null)
                return;
            Console.WriteLine(root.Data);
            PreSort(root.Left);
            PreSort(root.Right);
        }

        public void MidSort(Node root)
        {
            if (root == null)
                return;

            MidSort(root.Left);
            Console.WriteLine(root.Data);
            MidSort(root.Right);
        }

        public void PostSort(Node root)
        {
            if (root == null)
                return;
            PostSort(root.Left);
            PostSort(root.Right);
            Console.WriteLine(root.Data);
        }

        public void PreSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node current = root;

            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    stack.Push(current);
                    current = current.Left;
                }

                if (stack.Count > 0)
                {
                    current = stack.Pop();
                    current = current.Right;
                }

            }
        }

        public void MidSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node current = root;

            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                if (stack.Count > 0)
                {
                    current = stack.Pop();
                    Console.WriteLine(current.Data);
                    current = current.Right;
                }
            }
        }

        public void PostSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node current = root;
            stack.Push(current);
            Node lastNode = null; //上次的节点

            while (stack.Count > 0)
            {
                current = stack.Peek();

                if ((current.Left == null && current.Right == null) ||
                    (lastNode != null && (current.Left == lastNode || current.Right == lastNode)))
                {
                    current = stack.Pop();
                    Console.WriteLine(current.Data);
                    lastNode = current;
                }
                else
                {
                    if (current.Right != null)
                        stack.Push(current.Right);

                    if (current.Left != null)
                        stack.Push(current.Left);
                }
            }
        }

        public void SequenceSort(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            Node currentNode = root;
            queue.Enqueue(currentNode);
            int depth = GetDepth(root);

            Node nullNode = new Node(-1);

            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                Console.WriteLine(currentNode.Data);

                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);

                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
            }
        }

        public int GetDepth(Node root)
        {
            if (root == null)
                return 0;

            int left = GetDepth(root.Left);
            int right = GetDepth(root.Right);

            return left > right ? (left + 1) : (right + 1);
        }

        public void Delete(int value)
        {
            Node current = root;
            Node parent = null;

            while (current.Data != value)
            {
                parent = current;
                if (value < current.Data)
                    current = current.Left;
                else
                    current = current.Right;

                if (current == null)
                {
                    Console.WriteLine("Not Found!");
                    break;
                }
            }

            if (current != null)
            {
                if (current.Left == null && current.Right != null)
                {
                    if (root == current)
                        root = null;
                    else
                    {
                        if (parent.Left == current)
                            parent.Left = null;
                        else
                            parent.Right = null;
                    }
                }
                else if (current.Left != null && current.Right == null)
                {
                    if (root == current)
                        root = current.Left;
                    else
                    {
                        if (parent.Left == current)
                            parent.Left = current.Left;
                        else
                            parent.Right = current.Left;
                    }
                }
                else if (current.Left == null && current.Right != null)
                {
                    if (root == current)
                        root = current.Right;
                    else
                    {
                        if (parent.Left == current)
                            parent.Left = current.Right;
                        else
                            parent.Right = current.Right;
                    }
                }
                else //有双节点
                {
                    Node successor = SuccessorNode(current); //取得右枝丫
                    if (root == current)
                        root = successor;
                    else
                    {
                        if (parent.Left == current)
                            parent.Left = successor;
                        else
                            parent.Right = successor;
                    }
                    successor.Left = current.Left;
                }
            }
        }

        public Node SuccessorNode(Node delNode) //处理节点下还有双节点的特殊情况
        {
            Node successorParent = delNode; //存放右枝丫较大数值节点
            Node successorNode = delNode; //存放右枝丫最小的值节点
            Node current = delNode.Right;

            while (current != null)//找到右枝丫最小的值
            {
                successorParent = successorNode;
                successorNode = current;
                current = current.Left;
            }

            if (successorNode != null)
            {
                successorParent.Left = successorNode.Right; //若还有右最下的节点。那么赋值给successorParent
                successorNode.Right = delNode.Right; //将删除节点的右节点放置当前节点的右节点
            }

            return successorNode;
        }

        public Node ConversionToLinkList(Node root)
        {
            Node current = root;
            Stack<Node> stack = new Stack<Node>();
            Node head = null;
            Node temp = null;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                if (stack.Count > 0)
                {
                    current = stack.Pop();

                    if (head == null)
                    {
                        head = current;
                    }

                    if (temp != null)
                    {
                        temp.Right = current;
                    }
                    temp = current;
                    current = current.Right;
                }
            }

            return head;
        }

        public Node GetNodeByValue(Node root,int value)
        {
            if (root == null)
                return root;

            if (root.Data == value)
                return root;

            Node leftNode =  GetNodeByValue(root.Left, value);
            Node rightNode = GetNodeByValue(root.Right, value);

            if (leftNode != null)
                return leftNode;
            else if (rightNode != null)
                return rightNode;

            return null;
        }

        //查找最近的公共祖先节点
        /*
      注意p,q必然存在树内, 且所有节点的值唯一!!!
      递归思想, 对以root为根的(子)树进行查找p和q, 如果root == null || p || q 直接返回root
      表示对于当前树的查找已经完毕, 否则对左右子树进行查找, 根据左右子树的返回值判断:
      1. 左右子树的返回值都不为null, 由于值唯一左右子树的返回值就是p和q, 此时root为LCA
      2. 如果左右子树返回值只有一个不为null, 说明只有p和q存在与左或右子树中, 最先找到的那个节点为LCA
      3. 左右子树返回值均为null, p和q均不在树中, 返回null
      */
        public static Node LowestCommonAncestor(Node root, Node p, Node q)
        {
            if (root == null)
                return root;

            if (root == p || root == q) //根节点
                return root;

            Node left = LowestCommonAncestor(root.Left, p, q);
            Node right = LowestCommonAncestor(root.Right, p, q);
            if (left != null && right != null) //公共节点
                return root;
            else if (left != null)
                return left;
            else if (right != null)
                return right;

            return null;
        }
    }
}
