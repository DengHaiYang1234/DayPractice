using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void Insert(int item)
        {
            Node newItem = new Node(item);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                Node currentNode = root;
                Node parentNode = null;
                while (true)
                {
                    parentNode = currentNode;
                    if (item < currentNode.Data)
                    {
                        currentNode = currentNode.Left;
                        if (currentNode == null)
                        {
                            parentNode.Left = newItem;
                            break;
                        }
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                        if (currentNode == null)
                        {
                            parentNode.Right = newItem;
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
                if (current != null)
                {
                    Console.WriteLine(current.Data);
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    current = current.Right;
                }
            }
        }

        public void MidSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node currentNode = root;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = stack.Pop();
                    Console.WriteLine(currentNode.Data);
                    currentNode = currentNode.Right;
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
                    Console.WriteLine(current.Data);
                    lastNode = stack.Pop();
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
    }
}
