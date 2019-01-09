using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
