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
    }
}
