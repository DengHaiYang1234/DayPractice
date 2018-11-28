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

        public int Min()
        {
            Node temp = root;
            while (temp.Left != null)
                temp = temp.Left;

            return temp.Data;
        }

        public int Max()
        {
            Node temp = root;
            while (temp.Right != null)
                temp = temp.Right;

            return temp.Data;
        }

        public int GetTotalNodeNum(Node root)
        {
            if (root == null)
                return 0;

            int left = GetTotalNodeNum(root.Left);
            int right = GetTotalNodeNum(root.Right);

            return left + right + 1;
        }


        public int Depth(Node root)
        {
            if (root == null)
                return 0;

            int left = Depth(root.Left);
            int right = Depth(root.Right);

            return left > right ? (left + 1) : (right + 1);
        }

        public int GetNodeNumBy_KLevel(int k,Node root)
        {
            if (root == null || k < 1)
                return 0;

            if (k == 1)
                return 1;

            int left = GetNodeNumBy_KLevel(k - 1, root.Left);
            int right = GetNodeNumBy_KLevel(k - 1, root.Right);

            return left + right;
        }


        public void Delete(int value)
        {
            Node currentNode = root;
            Node parentNode = null;

            while (currentNode.Data !=  value)
            {
                parentNode = currentNode;
                if (value < currentNode.Data)
                    currentNode = currentNode.Left;
                else
                    currentNode = currentNode.Right;


                if (currentNode == null)
                {
                    Console.WriteLine("为找到");
                    return;
                }
            }

            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (root == currentNode)
                    root = null;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = null;
                else
                    parentNode.Right = null;
            }
            else if (currentNode.Left != null && currentNode.Right == null)
            {
                if (root == currentNode)
                    root = currentNode.Left;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = currentNode.Left;
                else
                    parentNode.Right = currentNode.Left;
            }
            else if (currentNode.Right != null && currentNode.Left == null)
            {
                if (root == currentNode)
                    root = currentNode.Right;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = currentNode.Right;
                else
                    parentNode.Right = currentNode.Right;
            }
            else
            {
                Node successor = GetScuuessor(currentNode);
                if (root == currentNode)
                    root = successor;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = successor;
                else
                    parentNode.Right = successor;

                successor.Left = currentNode.Left;
            }

        }

        public Node GetScuuessor(Node delNode)
        {
            Node successorParent = delNode;
           
            Node successor = delNode;

            Node currentNode = delNode.Right;

            while (currentNode != null)
            {
                successorParent = successor;
                successor = currentNode;
                currentNode = currentNode.Left;
            }

            if (successor != null)
            {
                successorParent.Left = successor.Right;
                successor.Right = delNode.Right;
            }

            return successor;
        }


        public static Node ConverBalanceTreeDoubleList(Node root)
        {
            if (root == null)
                return null;

            Node head = null;
            Node current = root;
            Node parentNode = null;

            Stack<Node> stack = new Stack<Node>();
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

                    if (head == null)
                        head = current;

                    if (parentNode != null)
                        parentNode.Right = current;

                    parentNode = current;

                    current = current.Right;
                }
            }
            return head;
        }
        
             







    }
}
