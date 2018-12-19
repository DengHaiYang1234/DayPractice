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

        public void SequenceSort(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            Node currentNode = root;
            queue.Enqueue(root);
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

        public int Min(Node root)
        {
            Node currentNode = root;
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }
            return currentNode.Data;
        }

        public int Max()
        {
            Node currentNode = root;
            while (currentNode.Right != null)
            {
                currentNode = currentNode.Right;
            }
            return currentNode.Data;
        }

        public int GetTotalNodeNum(Node root)
        {
            if (root == null)
            {
                return 0;
            }

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

        public int GetNodeNumBy_KLevel(int k ,Node root)
        {
            if (root == null || k < 1)
            {
                return 0;
            }

            if (k == 1)
            {
                return 1;
            }

            int left = GetNodeNumBy_KLevel(k - 1, root.Left);
            int right = GetNodeNumBy_KLevel(k - 1, root.Right);

            return left + right;
        }

        public Node ConversionToDoubleLinkList(Node root)
        {
            Node head = null;
            Node parent = null;
            Node curr = root;
            Stack<Node> stack = new Stack<Node>();
            while (curr != null || stack.Count > 0)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        curr = stack.Pop();

                        if (head == null)
                        {
                            head = curr;
                        }

                        if (parent != null)
                            parent.Right = curr;

                        parent = curr;
                        curr = curr.Right;
                    }
                }
            }

            return head;
        }

        public void Delete(int value)
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
                    Console.WriteLine("未找到有效的值");
                    break;
                }
            }

            if (current != null)
            {
                if (current.Left == null && current.Right == null) //单个
                {
                    if (current == root)
                    {
                        root = null;
                    }
                    else if (parent.Left == current)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }
                else if (current.Left != null && current.Right == null) //单左
                {
                    if (current == root)
                    {
                        root = current.Left;
                    }
                    else if (parent.Left == current)
                        parent.Left = current.Left;
                    else
                        parent.Right = current.Right;
                }
                else if (current.Right != null && current.Left == null) //单右
                {
                    if (current == root)
                        root = current.Right;
                    else if (parent.Left == current)
                        parent.Left = current.Right;
                    else
                        parent.Right = current.Right;
                }
                else if (current.Left != null && current.Right != null)
                {
                    Node successor = GetScuuessor(current);
                    if (root == current)
                        root = successor;
                    else if (parent.Left == current)
                        parent.Left = successor;
                    else
                        parent.Right = successor;

                    successor.Left = current.Left;
                }
            }
        }

        public Node GetScuuessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node currentNode = delNode.Right;

            while(currentNode != null)
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
    }
}
