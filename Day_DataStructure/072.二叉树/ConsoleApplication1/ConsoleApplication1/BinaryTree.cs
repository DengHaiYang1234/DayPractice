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
        private Node current;
        private Node parent;

        public BinaryTree()
        {
            root = null;
            current = null;
            parent = null;
        }

        public void Insert(int value)
        {
            Node newItem = new Node(value);
            current = root;
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                while (true)
                {
                    parent = current;
                    if (value < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newItem;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newItem;
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

            while (temp != null || stack.Count > 0)
            {
                while (temp != null)
                {
                    Console.WriteLine(temp.Data);
                    stack.Push(temp);
                    temp = temp.Left;
                }

                if (stack.Count > 0)
                {
                    Node _temp = stack.Pop();
                    temp = _temp.Right;
                }
            }
        }

        public void MidSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp = root;

            while (temp != null || stack.Count > 0)
            {
                while (temp != null)
                {
                    stack.Push(temp);
                    temp = temp.Left;
                }

                if (stack.Count > 0)
                {
                    Node _temp = stack.Pop();
                    Console.WriteLine(_temp.Data);
                    temp = _temp.Right;
                }
            }

        }

        public void PostSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp = root;
            //记录上一弹出节点
            Node preNode = null;
            stack.Push(temp);

            while (stack.Count > 0)
            {
                temp = stack.Peek();
                //注：         7
                //           6  9
                //以上为例：因为入栈的顺序是先右后左，那么出栈的顺序就是先左后右。
                // 先左： 当为6时,Left == null Right == null.那么preNode = 6
                // 后右： 当为9时,Left == null Right == null.那么preNode = 9
                // 依次出栈  现在为7，那么 temp = 7.(此时记录了preNode == 9)因为左右节点都已经出栈了,那么preNode == temp.Right.即7出栈
                if (temp.Left == null && temp.Right == null ||
                    (preNode != null && (preNode == temp.Left || preNode == temp.Right)))
                {
                    Console.WriteLine(temp.Data);
                    preNode = stack.Pop();
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

        public Node Min(Node root)
        {
            Node temp = root;
            while (temp.Left != null)
                temp = temp.Left;

            return temp;
        }

        public Node Max(Node root)
        {
            Node temp = root;
            while (temp.Right != null)
                temp = temp.Right;
            return temp;
        }

        public Node Find(int key)
        {
            Node temp = root;

            while (temp.Data != key)
            {
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

            //上一层节点的左节点开始
            int left = GetNodeNumBy_KLevel(k - 1, root.Left);
            //上一层节点的右节点开始
            int right = GetNodeNumBy_KLevel(k - 1, root.Right);
            return (left + right);
        }

        public void LevelTraverse(Node root)
        {
            Queue<Node> queue = new Queue<Node>();

            Node temp = root;

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                temp = queue.Dequeue();
                Console.WriteLine(temp.Data);

                if (temp.Left != null)
                {
                    queue.Enqueue(temp.Left);
                }
                if(temp.Right != null)
                {
                    queue.Enqueue(temp.Right);
                }
            }

        }

        public static bool StructureCmp(Node root1,Node root2)
        {
            if (root1 == null || root2 == null)
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
            Node currentNode = this.root;
            Node parentNode = null;

            //找到key对应的Node
            while (key != currentNode.Data)
            {
                parentNode = currentNode;
                if (key < currentNode.Data)
                    currentNode = currentNode.Left;
                else
                    currentNode = currentNode.Right;

                if (currentNode == null)
                {
                    Console.WriteLine("未找到该元素");
                    return;
                }
            }

            //第一种情况：该节点下不存在 left & right
            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (root == currentNode)
                    root = null;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = null;
                else if (parentNode.Right == currentNode)
                    parentNode.Right = null;
            }
            //第二种情况：该节点下存在 left ！= null
            else if (currentNode.Left != null && currentNode.Right == null)
            {
                if (root == currentNode)
                    root = currentNode.Left;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = currentNode.Left;
                else if (parentNode.Right == currentNode)
                    parentNode.Right = currentNode.Left;
            }
            //第三种情况：该节点下存在 right != null
            else if (currentNode.Right != null && currentNode.Left == null)
            {
                if (root == null)
                    root = currentNode.Right;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = currentNode.Right;
                else if (parentNode.Right == currentNode)
                    parentNode.Right = currentNode.Right;
            }
            //第四种情况：该节点下存在 left != null && right != null
            else
            {
                Node succsessor = GetSuccessor(currentNode);
                if (root == currentNode)
                    root = succsessor;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = succsessor;
                else
                    parentNode.Right = succsessor;

                //最后将未连接的左节点赋值给当前节点
                succsessor.Left = currentNode.Left;
            }

        }

        /*从右开始，找到最小的值（successor）；将最小值的父节点（successorParent）的左节点赋空；在用最小值对应节点连接删除的右节点（即当前节点的父节点也行），
         便可完成删除操作。*/
        public Node GetSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;

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

        public static Node ConverBalanceTreeDoubleList(Node root)
        {
            if (root == null )
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

                if (stack.Count > 0)
                {
                    current = stack.Pop();

                    //初始化头节点
                    if (head == null)
                        head = current;

                    //串联后续节点
                    if (preTreeNode != null)
                        preTreeNode.Right = current;

                    //定位到最后一个节点
                    preTreeNode = current;
                    //找下一个
                    current = current.Right;
                }
            }

            return head;
        }
    }
}
