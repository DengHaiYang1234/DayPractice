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
            Node newNode = new Node(value);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node currentNode = root;
                Node parentNode = null;

                while (currentNode != null)
                {
                    parentNode = currentNode;
                    if (value < currentNode.Data)
                    {
                        currentNode = currentNode.Left;
                        if (currentNode == null)
                        {
                            parentNode.Left = newNode;
                            break;
                        }
                            
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                        if (currentNode == null)
                        {
                            parentNode.Right = newNode;
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
            Node temp = root;

            while (stack.Count > 0 || temp != null)
            {
                if (temp != null)
                {
                    stack.Push(temp);
                    Console.WriteLine(temp.Data);
                    temp = temp.Left;
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        temp =  stack.Pop();
                        temp = temp.Right;
                    }
                }
            }
        }

        public void MidSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();

            Node temp = root;

            while (stack.Count > 0 || temp != null)
            {
                if (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.Left;
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        temp = stack.Pop();
                        Console.WriteLine(temp.Data);
                        temp = temp.Right;
                    }
                }
            }
        }

        public void PostSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp = root;
            stack.Push(root);
            Node childNode = null;

            while (stack.Count > 0)
            {
                temp = stack.Peek();

                if (temp.Left == null && temp.Right == null ||
                    (childNode != null && (childNode == temp.Left || childNode == temp.Right)))
                {
                    Console.WriteLine(temp.Data);
                    childNode = stack.Pop();
                }
                else
                {
                    if (temp.Right != null)
                        stack.Push(temp.Right);
                    if (temp.Left != null)
                        stack.Push(temp.Left);
                }
            }
        }

        public void SequenceSort(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            Node temp = root;

            while (queue.Count > 0)
            {
                temp = queue.Dequeue();
                Console.WriteLine(temp.Data);

                if(temp.Left != null)
                    queue.Enqueue(temp.Left);

                if(temp.Right != null)
                    queue.Enqueue(temp.Right);
            }

        }
    }
}
