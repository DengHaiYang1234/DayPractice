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

        public void Insert(int value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else
            {
                Node current = root;
                Node parent = null;
                Node newNode = new Node(value);

                while (true)
                {
                    parent = current;
                    if (value < current.Data)
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
            Node lastNode = null;
            stack.Push(root);

            while (stack.Count > 0)
            {
                current = stack.Peek();
                if (current.Left == null && current.Right == null ||
                    (lastNode != null && (current.Left == lastNode || current.Right == lastNode)))
                {
                    current = stack.Pop();
                    lastNode = current;
                    Console.WriteLine(lastNode.Data);
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

        public void SeqSort(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            Node current = root;

            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                Console.WriteLine(current.Data);

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }
                
                if(current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }

        public void Del(int value)
        {
            Node current = root;
            Node parent = null;

            while (value != current.Data)
            {
                parent = current;
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
                    Console.WriteLine("not find!");
                    break;
                }
            }

            if (current == null)
                return;

            if (current.Left == null && current.Right == null)
            {
                if (root == current)
                    root = null;
                else
                {
                    if (parent.Left == current)
                    {
                        parent.Left = null;
                    }
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
                    {
                        parent.Left = current.Left;
                    }
                    else
                        parent.Right = current.Left;
                }
            }
            else if (current.Right != null && current.Left == null)
            {
                if (root == current)
                    root.Right = current.Right;
                else
                {
                    if (parent.Left == current)
                        parent.Left = current.Right;
                    else
                        parent.Right = current.Right;
                }
            }
            else
            {
                Node successor = GetSuccessor(current);
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

        public Node GetSuccessor(Node delNode)
        {
            Node successor = delNode;
            Node successorParent = delNode;
            Node current = delNode.Right; //找到

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

        public static Node ConverToDoubleLinkList(Node root)
        {
            Node current = root;
            Stack<Node> stack = new Stack<Node>();
            Node nextNode = null;
            Node head = null;

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

                    if (nextNode != null)
                    {
                        nextNode.Right = current;
                    }
                    nextNode = current;
                    current = current.Right;
                }
            }

            return head;
        }

        public Node GetCommonRecentlyNode(Node root, int value1,int value2)
        {
            if (root == null)
                return null;

            if (root.Data == value1 || root.Data == value2)
                return root;

            Node leftNode = GetCommonRecentlyNode(root.Left, value1, value2);
            Node rightNode = GetCommonRecentlyNode(root.Right, value1, value2);

            if (leftNode != null && rightNode != null)
                return root;
            else if (leftNode != null)
                return leftNode;
            else if (rightNode != null)
                return rightNode;
            return null;
        }

        public Node GetNodeByValue(Node root,int value)
        {
            if (root == null)
                return null;

            if (root.Data == value)
                return root;

            Node leftNode = GetNodeByValue(root.Left, value);
            Node rightNode = GetNodeByValue(root.Right, value);

            if (leftNode != null)
                return leftNode;
            else if (rightNode != null)
                return rightNode;


            return null;
        }

        public static Node GetCompleteTree(int[] arr)
        {
            if (arr.Length == 1)
            {
                return new Node(arr[1]);
            }

            List<Node> nodeList = new List<Node>();
            for (int i = 0; i < arr.Length; i++)
            {
                nodeList.Add(new Node(arr[i]));
            }
            int temp = 0;

            while (temp <= (arr.Length - 2)/2)
            {
                if (temp*2 + 1 != 0)
                    nodeList[temp].Left = nodeList[temp*2 + 1];
                else if (temp*2 + 2 != 0)
                    nodeList[temp].Right = nodeList[temp*2 + 2];

                temp++;
            }

            return nodeList[0];
        }
    }
}
