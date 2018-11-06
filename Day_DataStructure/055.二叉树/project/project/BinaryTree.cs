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
            Node currNode = root;
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                while (true)
                {
                    Node parent = currNode;

                    if (value < currNode.Data)
                    {
                        currNode = currNode.Left;
                        if (currNode == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        currNode = currNode.Right;
                        if (currNode == null)
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

        public void LastSort(Node root)
        {
            if (root == null)
                return;
            LastSort(root.Left);
            LastSort(root.Right);
            Console.WriteLine(root.Data);
        }

        public void PreSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp = root;

            while (temp != null || stack.Count != 0)
            {
                while (temp != null)
                {
                    Console.WriteLine(temp.Data);
                    stack.Push(temp);
                    temp = temp.Left;
                }

                if (stack.Count != 0)
                {
                    temp = stack.Pop();
                    temp = temp.Right;
                }
            }
        }

        public void MidSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp = root;

            while (temp != null || stack.Count != 0)
            {
                while (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.Left;
                }

                if (stack.Count != 0)
                {
                    Console.WriteLine(stack.Peek().Data);
                    temp = stack.Pop();
                    temp = temp.Right;
                }
            }

        }

        public void LastSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp = null;
            Node parent = null;
            stack.Push(root);

            while (stack.Count != 0)
            {
                temp = stack.Peek();

                if (temp.Left == null && temp.Right == null ||
                    (parent != null && (parent == temp.Left || parent == temp.Right)))
                {
                    Console.WriteLine(temp.Data);
                    stack.Pop();
                    parent = temp;
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

        public int Min(Node root)
        {
            Node temp = root;
            while (temp.Left != null)
                temp = temp.Left;

            return temp.Data;
        }

        public int Max(Node root)
        {
            Node temp = root;
            while (temp.Right != null)
                temp = temp.Right;

            return temp.Data;
        }

        public Node Find(int key)
        {
            Node temp = root;
            while (temp != null)
            {
                if (temp.Data.Equals(key))
                    break;

                if (key < temp.Data)
                    temp = temp.Left;
                else
                    temp = temp.Right;
            }

            return temp;
        }

        public int GetTotalNodeNum(Node root)
        {
            if (root == null)
                return 0;
            return GetTotalNodeNum(root.Left) + GetTotalNodeNum(root.Right) + 1;
        }

        public int Depth(Node root)
        {
            if (root == null)
                return 0;
            int left = Depth(root.Left);
            int right = Depth(root.Right);

            return left > right ? (left + 1) : (right + 1);
        }

        public int GetNodeNumBy_KLevel(int k, Node root)
        {
            if (root == null || k < 1)
                return 0;

            if (k == 1)
                return 1;

            int numLeft = GetNodeNumBy_KLevel(k - 1, root.Left);
            int numRight = GetNodeNumBy_KLevel(k - 1, root.Right);
            return (numLeft + numRight);
        }

        public void LevelTraverse(Node root)
        {
            Queue<Node> queue = new Queue<Node>();

            Node temp = root;

            queue.Enqueue(root);

            int depth = Depth(temp);
            List<int[]> _ls = new List<int[]>();

            for (int i = 1; i <= depth; i++)
            {
                int count = GetNodeNumBy_KLevel(i, temp);
                Console.WriteLine(count);
                int[] arr = new int[count];
                _ls.Add(arr);
            }

            int index = 0;
            int arrIndex = 0;

            while (queue.Count != 0)
            {
                temp = queue.Dequeue();
                //Console.WriteLine(temp.Data);

                _ls[index][arrIndex] = temp.Data;
                arrIndex += 1;

                if (arrIndex >= _ls[index].Length)
                {
                    index = index + 1;
                    arrIndex = 0;
                }

                if (temp.Left != null)
                    queue.Enqueue(temp.Left);

                if (temp.Right != null)
                    queue.Enqueue(temp.Right);
            }

            for (int i = 0; i < _ls.Count; i++)
            {
                Console.WriteLine("第" + (i + 1) + "层:");
                for (int j = 0; j < _ls[i].Length; j++)
                {
                    Console.WriteLine("数据：" + _ls[i][j]);
                }
            }
        }

        //两边结构是否相同
        public static bool StructureCmp(Node root1,Node root2)
        {
            if (root1 == null && root2 == null)
                return true;
            else if (root1 == null || root2 == null)
                return false;

            bool resultLeft = StructureCmp(root1.Left, root2.Left);
            bool resultRight = StructureCmp(root1.Right, root2.Right);

            return (resultLeft && resultRight);
        }

        public bool IsAVL(Node root, out int height)
        {
            if (root == null)
            {
                height = 0;
                return true;
            }

            int heightLeft;
            bool resultLeft = IsAVL(root.Left, out heightLeft);
            int heightRight;
            bool resultRight = IsAVL(root.Right, out heightRight);

            if (resultLeft && resultRight && Math.Abs(heightLeft - heightRight) <= 1)
            {
                height = Math.Max(heightLeft, heightRight) + 1;
                return true;
            }
            else
            {
                height = Math.Max(heightLeft, heightRight) + 1;
                return false;
            }
        }

        public Node Mirror(Node root)
        {
            if (root == null)
                return null;

            Node left = Mirror(root.Left);
            Node right = Mirror(root.Right);

            root.Left = right;
            root.Right = left;

            return root;
        }

    }
}
