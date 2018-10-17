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
        #region 层序遍历(画出二叉树)
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
    }
}
