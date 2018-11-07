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

        public void Delete(int key)
        {
            //当前要删除的节点
            Node currentNode = root;
            //上一节点
            Node parentNode = currentNode;
            bool isLeftChild = true;


            while (currentNode.Data != key)
            {
                parentNode = currentNode;
                if (key < currentNode.Data)
                {
                    isLeftChild = true;
                    currentNode = currentNode.Left;
                }
                else
                {
                    isLeftChild = false;
                    currentNode = currentNode.Right;
                }

                if (currentNode == null)
                {
                    Console.WriteLine("不存在该节点");
                    break;
                }
            }

            //要删除的节点下  没有左右节点
            if (currentNode.Left == null && currentNode.Right == null)
            {
                //如果当前节点为头结点
                if (currentNode == root)
                    root = null;

                //直接删除该左节点
                else if (isLeftChild)
                    parentNode.Left = null;
                //直接删除该右节点
                else
                    parentNode.Right = null;
            }

            //要删除的节点下  存在一个左节点.没有右节点
            else if (currentNode.Right == null && currentNode.Left != null)
            {
                //如果要删除为头结点  那么将头结点替换为原头节点的左节点即可
                if (currentNode == root)
                    root = currentNode.Left;
                //要删除的节点位于上一节点的左边 那么就将该节点的下一节点放在上一节点的左边.反之亦然
                else if (isLeftChild)
                    parentNode.Left = currentNode.Left;
                else
                    parentNode.Right = currentNode.Left;
            }

            //要删除的节点下  存在一个右节点.没有左节点
            else if (currentNode.Left == null && currentNode.Right != null)
            {
                if (currentNode == root)
                    root = currentNode.Right;
                else if (isLeftChild)
                    parentNode.Left = currentNode.Right;
                else
                    parentNode.Right = currentNode.Right;
            }
            //存在两个等级
            else
            {
                //先将currentNode的右边进行重新构造
                Node successor = GetSuccessor(currentNode);
                if (currentNode == root)
                    root = successor;
                else if (isLeftChild)
                    parentNode.Left = successor;
                else
                    parentNode.Right = successor;

                //再添加左边 就重构了二叉树
                successor.Left = currentNode.Left;
            }
        }

        public void OtherDelete(int key)
        {
            Node current = root;
            Node parent = current;
            while (true)
            {
                if (current.Data.Equals(key))
                    break;
                parent = current;

                if (key < current.Data)
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
                    break;
                }
            }

            if (current.Left == null && current.Right == null)
            {
                if (current == root)
                    root = null;
                else if (parent.Left == current)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
            else if (current.Left != null && current.Right == null)
            {
                if (current == root)
                    root = current.Left;
                else if (parent.Left == current)
                    parent.Left = current.Left;
                else
                    parent.Right = current.Left;
            }
            else if (current.Right != null && current.Left == null)
            {
                if (current == root)
                    root = current.Right;
                else if (parent.Left == current)
                    parent.Left = current.Right;
                else
                    parent.Right = current.Right;
            }
            else
            {
                Node successor = GetSuccessor(current);
                if (root == current)
                    root = successor;
                else if (parent.Left == current)
                    parent.Left = successor;
                else
                    parent.Right = successor;

                successor.Left = current.Left;
            }


        }

        public Node GetSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            //从当前节点的右节点开始
            Node current = delNode.Right;

            while (current != null)
            {
                //始终是当前节点（current）的前两个节点位置
                successorParent = successor;
                //始终是当前节点（current）的上一节点位置
                successor = current;
                //current = null.上一节点为delNode的最后的左节点(即上一节点为：successor)
                current = current.Left;
            }

            if (successor != delNode.Right)
            {
                //画图理解吧.....解释不了
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
            Node preTreeNode = null;
            Stack<Node> stack = new Stack<Node>();
            while (stack.Count != 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                if (stack.Count != 0)
                {
                    current = stack.Pop();
                    if (head == null)
                        head = current;

                    if (preTreeNode != null)
                    {
                        preTreeNode.Right = current;
                    }

                    preTreeNode = current;
                    current = current.Right;
                }
            }
            return head;
        }

        public static Node ConverBalanceTreeDoubleListRecursion(Node root)
        {
            if (root == null || (root.Left == null && root.Right == null))
                return root;

            Node temp = null;
            if (root.Left != null)
            {
                temp = ConverBalanceTreeDoubleListRecursion(root.Left);
                while (temp.Right != null)
                    temp = temp.Right;
                temp.Right = root;
                root.Left = temp;
            }

            if (root.Right != null)
            {
                temp = ConverBalanceTreeDoubleListRecursion(root.Right);
                while (temp.Left != null)
                    temp = temp.Left;
                temp.Left = root;
                root.Right = temp;
            }

            return root;

        }



    }
}
