using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_
{
    public class BinaryTree
    {
        public Node root;


        public BinaryTree()
        {
            root = null;
        }
        #region 插入
        public void Insert(int value)
        {
            Node newNode = new Node(value);
            Node curret = root;

            if(root == null)
            {
                root = newNode;
            }
            else
            {
                while(true)
                {
                    Node parent = curret;
                    if(value < curret.Data)
                    {
                        curret = curret.Left;
                        if(curret == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        curret = curret.Right;
                        if(curret == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }
        #endregion
        #region 递归排序
        public void PreSort(Node root)
        {
            if (root == null)
                return;
            Console.WriteLine(root.Data);
            PreSort(root.Left);
            PreSort(root.Right);
        }

        public void InSort(Node root)
        {
            if (root == null)
                return;
            InSort(root.Left);
            Console.WriteLine(root.Data);
            InSort(root.Right);
        }

        public void PostSort(Node root)
        {
            if (root == null)
                return;
            PostSort(root.Left);
            PostSort(root.Right);
            Console.WriteLine(root.Data);
        }
        #endregion
        #region 非递归
        public void PreSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node curret = root;
            while(curret != null || stack.Count != 0)
            {
                while(curret != null)
                {
                    Console.WriteLine(curret.Data);
                    stack.Push(curret);
                    curret = curret.Left;
                }

                if(stack.Count != 0)
                {
                    curret = stack.Pop();
                    curret = curret.Right;
                }
            }
        }

        public void InSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            Node curret = root;
            while(curret != null || stack.Count != 0)
            {
                while(curret != null)
                {
                    stack.Push(curret);
                    curret = curret.Left;
                }

                if(stack.Count != 0)
                {
                    curret = stack.Pop();
                    Console.WriteLine(curret.Data);
                    curret = curret.Right;
                   
                }
            }
        }

        public void PostSortByNoram(Node root)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            Node curret = root;
            Node preNode = null;
            while(stack.Count != 0)
            {
                curret = stack.Peek();
                if((curret.Left == null && curret.Right == null) || (preNode != null && (preNode == curret.Left || preNode == curret.Right)))
                {
                    Console.WriteLine(curret.Data);
                    stack.Pop();
                    preNode = curret;
                }
                else
                {
                    if (curret.Right != null)
                        stack.Push(curret.Right);
                    if (curret.Left != null)
                        stack.Push(curret.Left);
                }
            }
        }
        #endregion
        #region 找最小的值
        public int Min()
        {
            Node curret = root;
            while(curret.Left != null)
            {
                curret = curret.Left;
            }
            return curret.Data;
        }
        #endregion
        #region 找最大的值
        public int Max()
        {
            Node curret = root;
            while(curret.Right != null)
            {
                curret = curret.Right;
            }
            return curret.Data;
        }
        #endregion
        #region 根据Key找节点(非递归)
        public Node Find(int key)
        {
            Node curret = root;

            while (curret != null)
            {
                if (curret.Data.Equals(key))
                    break;

                if(key < curret.Data)
                {
                    curret = curret.Left;
                }

                if(key > curret.Data)
                {
                    curret = curret.Right;
                }
            }
            return curret;
        }
        #endregion
        #region 二叉树总节点数(递归)
        public int GetNodeNum(Node root)
        {
            if (root == null)
                return 0;
            //左节点和有节点都为空时。该节点为num为1
            return GetNodeNum(root.Left) + GetNodeNum(root.Right) + 1;
        }
        #endregion
        #region 二叉树总节点数(非递归)
        public int GetNodeNumByNoram()
        {
            Stack<Node> stack = new Stack<Node>();
            int num = 0;

            Node currNode = null; 
            Node preNode = null;
            stack.Push(root);
            while(stack.Count != 0)
            {
                currNode = stack.Peek();
                if((currNode.Left == null && currNode.Right == null) || (preNode != null &&(preNode == currNode.Left || preNode == currNode.Right)))
                {
                    num++;
                    stack.Pop();
                    preNode = currNode;
                }
                else
                {
                    if (currNode.Right != null)
                        stack.Push(currNode.Right);
                    if (currNode.Left != null)
                        stack.Push(currNode.Left);
                }
            }

            return num;
        }
        #endregion
        #region 二叉树的深度
        public int Depth(Node root)
        {
            if (root == null)
                return 0;
            int depthLeft = Depth(root.Left);
            int depthRight = Depth(root.Right);

            return depthLeft > depthRight ? (depthLeft + 1) : (depthRight + 1);
        }
        #endregion
        #region 求第k层的节点总数
        public int GetNodeNumByK_Level(int k,Node root)
        {
            if(root == null || k < 1)
            {
                return 0;
            }

            if(k == 1)
            {
                return 1;
            }

            int numLeft = GetNodeNumByK_Level(k - 1, root.Left);
            int numRight = GetNodeNumByK_Level(k - 1, root.Right);
            return (numLeft + numRight);
        }
        #endregion
        #region 层序遍历(每层节点)
        public void LevelTraverse(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            Node currNode = root;

            int depth = Depth(currNode);
            List<int[]> _ls = new List<int[]>();

            for(int i = 1;i <= depth;i++)
            {
                int count = GetNodeNumByK_Level(i, currNode);
                int[] arr = new int[count];
                _ls.Add(arr);
            }

            int index = 0;
            int arrIndex = 0;

            while(queue.Count != 0)
            {
                currNode = queue.Dequeue();
                //Console.WriteLine(currNode.Data);

                _ls[index][arrIndex] = currNode.Data;
                arrIndex += 1;
                if (arrIndex >= _ls[index].Length)
                {
                    index = index + 1;
                    arrIndex = 0;
                }

                if(currNode.Left != null)
                {
                    //Console.WriteLine("左边的元素：" + currNode.Left.Data);
                    queue.Enqueue(currNode.Left);
                }
                    
                if(currNode.Right != null)
                {
                    //Console.WriteLine("右边的元素：" + currNode.Right.Data);
                    queue.Enqueue(currNode.Right);
                }  
            }

            for(int i = 0; i< _ls.Count;i++)
            {
                Console.WriteLine("第" + (i + 1) + "层:");
                for(int j = 0; j < _ls[i].Length;j++)
                {
                    Console.WriteLine("数据：" + _ls[i][j]);
                }
            }
        }
        #endregion
        #region 判断两颗二叉树是否结构相同
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
        #endregion
        #region 二叉树深度
        public int BinaryTreeDepth(Node root)
        {
            if (root == null)
                return 0;

            int depthLeft = BinaryTreeDepth(root.Left);
            int depthRight = BinaryTreeDepth(root.Right);

            return depthLeft > depthRight ? (depthLeft + 1) : (depthRight + 1); 
        }
        #endregion
        #region 某层的节点数
        //每层左节点加有节点的和
        public int GetLevelNodeNumBy_K(Node root,int k)
        {
            if (root == null || k < 1)
                return 0;
            else if (k == 1)
                return 1;

            int leftNum = GetLevelNodeNumBy_K(root.Left, k - 1);
            int rightNum = GetLevelNodeNumBy_K(root.Right, k - 1);
            return (leftNum + rightNum);
        }
        #endregion
        #region 是否为平衡二叉树
        public bool IsAVL(Node root,out int height)
        {
            if(root == null)
            {
                height = 0;
                return true;
            }
            int heightLeft;
            bool resultLeft = IsAVL(root.Left, out heightLeft);
            int heightRight;
            bool resultRight = IsAVL(root.Right, out heightRight);

            if(resultLeft && resultRight && Math.Abs(heightLeft - heightRight) <= 1)
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
        #endregion
        #region 二叉树的镜像
        public Node Mirror(Node root)
        {
            if(root == null)
            {
                return null;
            }
            Node pLeft = Mirror(root.Left);
            Node pRight = Mirror(root.Right);

            root.Left = pRight;
            root.Right = pLeft;
            return root;
        }
        #endregion
        #region 删除 参考：https://blog.csdn.net/cai2016/article/details/52600687
        public void Delete(int key)
        {
            Node currentNode = root;
            Node parentNode = currentNode;
            bool isLeftChild = true;

            //删除没有子节点的节点(该节点删除的条件为该节点没有子树.只是一个节点)
            //找到为key值的节点
            while (currentNode.Data != key)
            {
                parentNode = currentNode;
                if(key < currentNode.Data)
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
                    Console.WriteLine("没有找到该节点");
                    break;
                }
            }
            //删除有一个子节点的节点
            if(currentNode.Left == null && currentNode.Right == null)
            {
                if (currentNode == root)
                    root = null;
                else if (isLeftChild)
                    parentNode.Left = null;
                else
                    parentNode.Right = null;
            }
            //如果无右子节点，则直接用该节点的父节点的左节点引用该节点的子节点
            else if (currentNode.Right == null && currentNode.Left != null)
            {
                //头结点
                if (currentNode == root)
                    root = currentNode.Left;
                //若该节点是父节点的左节点
                else if (isLeftChild)
                    parentNode.Left = currentNode.Left;
                //若该节点是父节点的右节点
                else
                    parentNode.Right = currentNode.Left;
            }
            //如果无左节点，则直接用该节点的父节点右节点引用该节点的子节点
            else if (currentNode.Left == null && currentNode.Right != null)
            {
                //头结点
                if (currentNode == root)
                    root = currentNode.Right;
                //若该节点是父节点的左节点
                else if (isLeftChild)
                    parentNode.Left = currentNode.Right;
                //若该节点是父节点的右节点
                else
                    parentNode.Right = currentNode.Right;
            }
            //若果存在两个节点
            else
            {
                Node successor = GetSuccessor(currentNode);
                if (currentNode == root)
                    root = successor;
                else if (isLeftChild)
                    parentNode.Left = successor;
                else
                    parentNode.Right = successor;
                successor.Left = currentNode.Left;
            }
        }
        #endregion
        #region 获取后续节点
        public Node GetSuccessor(Node delNode)
        {
            Node successorParent = delNode;
            Node successor = delNode;
            Node current = delNode.Right;
            while(current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.Left;
            }
            if(successor != delNode.Right)
            {
                successorParent.Left = successor.Right;
                successor.Right = delNode.Right;
            }
            return successor;
        }
        #endregion
        #region 同样是删除
        public void DeleteNode(int key)
        {
            Node currentNode = root;
            Node parentNode = null;

            while (currentNode.Data != key)
            {
                parentNode = currentNode;
                if (key < currentNode.Data)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }

                if (currentNode == null)
                {
                    Console.WriteLine("没有找到该节点");
                    break;
                }
            }

            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (currentNode == root)
                    root = null;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = null;
                else if (parentNode.Right == currentNode)
                    parentNode.Right = null;
            }
            else if (currentNode.Left == null && currentNode.Right != null)
            {
                if (currentNode == root)
                {
                    root = currentNode.Right;
                }
                else if (parentNode.Left == currentNode)
                    parentNode.Left = currentNode.Right;
                else if (parentNode.Right == currentNode)
                    parentNode.Right = currentNode.Right;
            }
            else if (currentNode.Right == null && currentNode.Left != null)
            {
                if (currentNode == root)
                    root = currentNode.Left;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = currentNode.Left;
                else if (parentNode.Right == currentNode)
                    parentNode.Right = currentNode.Left;
            }
            else
            {
                Node successor = GetSuccessor(currentNode);
                if (currentNode == root)
                    root = successor;
                else if (parentNode.Left == currentNode)
                    parentNode.Left = successor;
                else
                    parentNode.Right = successor;

                successor.Left = currentNode.Left;
            }
        }
        #endregion
        #region  将二叉树转换为双向链表(非递归利用中序)
        public static Node ConvertBalanceTreeDoubleList(Node root)
        {
            if (root == null)
                return null;
            Node head = null;
            Node current = root;
            Node preTreeNode = null;
            Stack<Node> stack = new Stack<Node>();
            while(stack.Count != 0 || current != null)
            {
                while(current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                if(stack.Count != 0)
                {
                    current = stack.Pop();
                    if(head == null)
                    {
                        head = current;
                    }
                    if(preTreeNode != null)
                    {
                        preTreeNode.Right = current;
                    }

                    preTreeNode = current;
                    current = current.Right;
                }
            }
            return head;
        }
        #endregion
        #region  将二叉树转换为双向链表(递归利用中序)
        public static Node ConvertBalanceTreeToDoubleListRecursion(Node root)
        {
            if (root == null || (root.Left == null && root.Right == null))
                return root;
            Node temp = null;
            if(root.Left != null)
            {
                temp = ConvertBalanceTreeToDoubleListRecursion(root.Left); // root为弹出的上一层。
                while (temp.Right != null) // 若该节点存在右节点。那么连接该节点便是
                    temp = temp.Right;
                temp.Right = root;
                root.Left = temp;
            }
            if(root.Right != null)
            {
                temp = ConvertBalanceTreeToDoubleListRecursion(root.Right);
                while (temp.Left != null)
                    temp = temp.Left;
                temp.Left = root;
                root.Right = temp;
            }
            return root;
        }
       
        #endregion
    }
}
