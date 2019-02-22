using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void Insert(int data)
        {
            Node newNode = new Node(data);
            
            Node preNode = null;

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node current = root;

                while (true)
                {
                    preNode = current;
                    if (data < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            preNode.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            preNode.Right = newNode;
                            break;
                        }
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

            while (current != null || stack.Count > 0)
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
            Node current = null;
            Node lastNode = null;
            stack.Push(root);
            while (stack.Count > 0)
            {
                current = stack.Peek();

                if (current.Left == null && current.Right == null ||
                    (lastNode != null && (lastNode == current.Left || lastNode == current.Right)))
                {
                    Console.WriteLine(current.Data);
                    lastNode = current;
                    current = stack.Pop();
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
            Node current = null;
            Node parentNode = null;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                Console.WriteLine(current.Data);

                if (current.Left != null)
                    queue.Enqueue(current.Left);

                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }

        public void Delete(int value)
        {
            Node current = root;

            Node parentNode = null;

            while (true)
            {
                parentNode = current;

                if (current.Data == value)
                {
                    break;
                }

                if (value < current.Data)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }

                if (current == null)
                {
                    Console.WriteLine("未找到");
                    return;
                }
            }

            if (current.Left == null && current.Right == null)
            {
                if (current == root)
                {
                    root = null;
                }
                else if (parentNode.Left == current)
                {
                    parentNode.Left = null;
                }
                else if (parentNode.Right == current)
                {
                    parentNode.Right = null;
                }
            }
            else if (current.Left != null && current.Right == null)
            {
                if (current == root)
                {
                    root = current.Left;
                }
                else if (parentNode.Left == current)
                    parentNode.Left = current.Left;
                else if (parentNode.Right == current)
                    parentNode.Right = current.Left;
            }
            else if (current.Left == null && current.Right != null)
            {
                if (current == root)
                {
                    root = current.Right;
                }
                else if (parentNode.Left == current)
                    parentNode.Left = current.Right;
                else if (parentNode.Right == current)
                    parentNode.Right = current.Right;
            }
            else
            {
                Node successor = GetSuccessor(current);
                if (current == root)
                    root = successor;
                else if (parentNode.Left == current)
                    parentNode.Left = successor;
                else if (parentNode.Right == current)
                    parentNode.Right = successor;

                successor.Left = current.Left;
            }
        }

        public Node GetSuccessor(Node delNode)
        {
            Node successor = delNode;
            Node successorParent = delNode;
            Node current = delNode.Right;

            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.Left;
            }

            if (successor != null)
            {
                successorParent.Left = successor.Right;
                successor.Right = delNode.Right;
            }

            return successor;
        }

        public static Node ConvertToDoubleLinkList(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node current = root;
            Node head = null;
            Node rear = null;

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

                    if (rear != null)
                    {
                        rear.Right = current;
                    }

                    rear = current;

                    current = current.Right;
                }
            }

            return head;
        }

        public Node GetNodeByValue(Node root,int value)
        {
            if (root == null)
                return null;

            if (root.Data == value)
                return root;

            Node left = GetNodeByValue(root.Left, value);
            Node right = GetNodeByValue(root.Right, value);

            if (left != null)
                return left;
            if (right != null)
                return right;

            return null;
        }

        public Node GetCommonNode(Node root,int value1,int value2)
        {
            if (root == null)
                return null;

            if (root.Data == value1 || root.Data == value2) //这个是已经找到的节点
            {
                Console.WriteLine(root.Data);
                return root;
            }
                

            Node left = GetCommonNode(root.Left, value1, value2);
            Node right = GetCommonNode(root.Right, value1, value2);

            if (left != null && right != null)
                return root;

            if (left != null)
                return left;

            if (right != null)
                return right;

            return null;
        }
    }
}
