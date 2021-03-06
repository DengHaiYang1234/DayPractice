﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class BinaryTree<T>
    {
        public Node<T> current;//当前节点

        Node<T> parent;//即将添加的节点的根节点(最后一个节点的父节点)

        public Node<T> root;
        public BinaryTree()
        {
            root = null;
        }

        public void InOrder(Node<T> theRoot)  //中序
        {
            if (theRoot == null)
                return;

            InOrder(theRoot.Left);
            Console.WriteLine(theRoot.Data);
            InOrder(theRoot.Right);
        }

        public void PostOrder(Node<T> theRoot) //后序
        {
            if (theRoot == null)
                return;
            PostOrder(theRoot.Left);
            PostOrder(theRoot.Right);
            Console.WriteLine(theRoot.Data);
        }

        public void PreOrder(Node<T> theRoot) //先序
        {
            if (theRoot == null)
                return;
            Console.WriteLine(theRoot.Data);
            PreOrder(theRoot.Left);
            PreOrder(theRoot.Right);
        }

        public void Insert(int value)
        {
            Node<T> newNode = new Node<T>(value);
            current = root;
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                while(true)
                {
                    parent = current;  // 当前还没有往下去进行时的节点
                    if (value < current.Data) //小于根节点.左边
                    {
                        current = current.Left; // 当前节点向左前进一位
                        if(current == null) //如果下个节点为空。也就是说可以在当前节点的下一个节点添加
                        {
                            parent.Left = newNode; //当前节点的下一个左节点可添加一个Node.
                            break;
                        }
                    }
                    else //大于根节点.右边
                    {
                        current = current.Right;
                        if(current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }


        public int Min()
        {
            current = root;
            while (current.Left != null)
                current = current.Left;
            return current.Data;
        }

        public int Max()
        {
            current = root;
            while (current.Right != null)
                current = current.Right;
            return current.Data;
        }

        public Node<T> Find(int key)
        {
            current = root;

            while(current != null)
            {
                if (key == current.Data)
                    break;
                if(key < current.Data)
                {
                    parent = current;
                    current = current.Left;
                }
                else
                {
                    parent = current;
                    current = current.Right;
                }
            }
            if (current == null)
                return null;
            else
                return current;
        }

        /// <summary>
        /// 求二叉树的总节点数
        /// </summary>
        /// <param name="theRoot"></param>
        /// <returns></returns>
        public int GetNodeNum(Node<T> theRoot)
        {
            if (theRoot == null)
                return 0;
            return GetNodeNum(theRoot.Left) + GetNodeNum(theRoot.Right) + 1;
        }

        /// <summary>
        /// 求二叉树的深度
        /// </summary>
        /// <param name="theRoot"></param>
        /// <returns></returns>
        public int GetDepth(Node<T> theRoot)
        {
            if (theRoot == null)
                return 0;
            int depthLeft = GetDepth(theRoot.Left);
            int depthRight = GetDepth(theRoot.Right);
            return depthLeft > depthRight ? (depthLeft + 1) : (depthRight + 1);
        }

        /// <summary>
        /// 分层遍历二叉树(从上至下，从左至右)(待定)
        /// </summary>
        /// <param name="theRoot"></param>
        public void LevelTraverse(Node<T> theRoot)
        {
            if(theRoot == null)
            {
                return;
            }

            Queue<Node<T>> tempList = new Queue<Node<T>>();
            tempList.Enqueue(theRoot);
            while(tempList.Peek() != null)
            {
                Node<T> temp = tempList.Peek();
                tempList.Dequeue();
                Console.WriteLine(temp.Data);
                if (temp.Left != null)
                    tempList.Enqueue(temp.Left);
                if (temp.Right != null)
                    tempList.Enqueue(temp.Right);

            }
        }
        /// <summary>
        /// 求第k层的节点总数
        /// </summary>
        /// <param name="theRoot"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetNodeNumKthLevel(Node<T> theRoot,int k)
        {
            if (theRoot == null || k < 1)
            {
                return 0;
            }

            if (k == 1)
                return 1;

            int numLeft = GetNodeNumKthLevel(theRoot.Left, k - 1);
            int numRight = GetNodeNumKthLevel(theRoot.Right, k - 1);
            return (numLeft + numRight);
        }

        /// <summary>
        /// 判断两颗二叉树是否结构相同
        /// </summary>
        /// <param name="theRoot1"></param>
        /// <param name="theRoot2"></param>
        /// <returns></returns>
        public static bool StructureCmp(Node<T> theRoot1,Node<T> theRoot2)
        {
            if (theRoot1 == null && theRoot2 == null)
                return true;
            else if (theRoot1 == null || theRoot2 == null)
                return false;
            bool resultLeft = StructureCmp(theRoot1.Left, theRoot2.Left);
            bool resultRight = StructureCmp(theRoot1.Right, theRoot2.Right);
            return (resultLeft && resultRight);
        }

        /// <summary>
        /// 判断二叉树是不是平衡二叉树
        /// （1）如果二叉树为空，返回真
        /// （2）如果二叉树不为空，如果左子树和右子树都是AVL树并且左子树和右子树高度相差不大于1，返回真，其他返回假
        /// </summary>
        /// <param name="theRoot"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public bool IsAVL(Node<T> theRoot,out int height)
        {
            if(theRoot == null)
            {
                height = 0;
                return true;
            }
            int heightLeft;
            bool resultLeft = IsAVL(theRoot.Left, out heightLeft);
            int heightRight;
            bool resultRight = IsAVL(theRoot.Right, out heightRight);
            if(resultLeft && resultRight && Math.Abs(heightLeft - heightRight) <= 1)// 左子树和右子树都是AVL，并且高度相差不大于1，返回真
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

        /// <summary>
        /// 求二叉树的镜像
        /// </summary>
        /// <param name="theRoot"></param>
        /// <returns></returns>
        public Node<T> Mirror(Node<T> theRoot)
        {
            if (theRoot == null)
                return null;
            Node<T> pLeft = Mirror(theRoot.Left);
            Node<T> pRight = Mirror(theRoot.Right);

            theRoot.Left = pRight;
            theRoot.Right = pLeft;
            return theRoot;
        }

        /// <summary>
        /// 将二叉查找树变为有序的双向链表
        /// </summary>
        /// <param name="theRoot"></param>
        /// <param name="pFirstNode"></param>
        /// <param name="pLastNode"></param>
        /// 如果左子树为空，对应双向有序链表的第一个节点是根节点，左边不需要其他操作；
        /// 如果左子树不为空，转换左子树，二叉查找树对应双向有序链表的第一个节点就是左子树转换后双向有序链表的第一个节点，同时将根节点和左子树转换后的双向有序链 表的最后一个节点连接；
        /// 如果右子树为空，对应双向有序链表的最后一个节点是根节点，右边不需要其他操作；
        /// 如果右子树不为空，对应双向有序链表的最后一个节点就是右子树转换后双向有序链表的最后一个节点，同时将根节点和右子树转换后的双向有序链表的第一个节点连 接。
        public void Convert(Node<T> theRoot,Node<T> pFirstNode,Node<T> pLastNode)
        {
            Node<T> pFirstLeft = new Node<T>();
            Node<T> pLastLeft = new Node<T>();
            Node<T> pFirstRight = new Node<T>();
            Node<T> pLastRight = new Node<T>();
            if (theRoot == null)
            {
                pFirstNode = null;
                pLastNode = null;
                return;
            }
            if(theRoot.Left == null)
            {
                // 如果左子树为空，对应双向有序链表的第一个节点是根节点
                pFirstNode = theRoot;
            }
            else
            {
                Convert(theRoot.Left, pFirstLeft, pLastLeft);
                // 二叉查找树对应双向有序链表的第一个节点就是左子树转换后双向有序链表的第一个节点
                pFirstNode = pFirstLeft;
                // 将根节点和左子树转换后的双向有序链表的最后一个节点连接
                theRoot.Left = pLastLeft;
                pLastLeft.Right = theRoot;
            }

            if(theRoot.Right == null)
            {
                // 对应双向有序链表的最后一个节点是根节点
                pLastNode = theRoot;
            }
            else
            {
                Convert(theRoot.Right, pFirstRight, pLastRight);
                // 对应双向有序链表的最后一个节点就是右子树转换后双向有序链表的最后一个节点
                pLastNode = pLastRight;
                // 将根节点和右子树转换后的双向有序链表的第一个节点连接
                theRoot.Right = pFirstRight;
                pFirstRight.Left = theRoot;
            }


        }

        public void treeToDoublyList(Node<T> p,Node<T> prev,Node<T> head)
        {
            if (p == null)
                return;
            treeToDoublyList(p.Left, prev, head);
            p.Left = prev;
            if (prev != null)
                prev.Right = p;
            else
                head = p;

            Node<T> right = p.Right;
            p.Right = head;
            head.Left = p;
            prev = p;
            treeToDoublyList(right, prev, head);            

        }
        public Node<T> treeToDoublyList(Node<T> theRoot)
        {
            Node<T> head = null;
            Node<T> pre = null;
            treeToDoublyList(theRoot, pre, head);
            return head;
        }
        /// <summary>
        /// *  递归实现将二叉查找树变为有序的双向链表,要求不能创建新节点，只调整指针(以根节点作为头结点)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        ///（1）如果一个节点是空树或者节点不存在左子树和右子树，则返回该节点
        ///（2）定义临时变量，用来接收递归出口得到的结果
        ///（3）如果返回的是左子树的左节点，中序遍历找到临时节点的最右边的节点，然后让临时变量的节点的右孩子指向树根，树根的左孩子指向临时节点
        ///（4）如果返回的是右子树的右节点，中序遍历找到临时节点的最左边的节点，然后让临时变量的节点的左孩子指向树根，树根的右孩子指向临时节点
        ///（5）这样完成二叉查找树变为有序的双向链表
        public static Node<T> convertBalanceTreeToDoubleListRecursion(Node<T> root)
        {
            if (root == null || (root.Left == null && root.Right == null))
                return root;
            Node<T> temp = null;
            if(root.Left != null)
            {
                temp = convertBalanceTreeToDoubleListRecursion(root.Left);
                while(temp.Right != null)
                {
                    temp = temp.Right;
                }
                temp.Right = root;
                root.Left = temp;
            }
            if(root.Right != null)
            {
                temp = convertBalanceTreeToDoubleListRecursion(root.Right);
                while (temp.Left != null)
                    temp = temp.Left;

                temp.Left = root;
                root.Right = temp;
            }

            return root;
        }

        /// <summary>
        /// 非递归变成链表
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static Node<T> convertBalanceTreeToDoubleList(Node<T> root)
        {
            if (root == null)
                return null;
            Node<T> head = null;
            Node<T> current = root;
            Node<T> preTreeNode = null;
            Stack<Node<T>> statck = new Stack<Node<T>>();
            while(statck.Count != 0 || current != null)
            {
                while (current != null)
                {
                    statck.Push(current);
                    current = current.Left;
                }
                if(statck.Count != 0)
                {
                    current = statck.Pop();
                    if (head == null)
                        head = current;
                    if (preTreeNode != null)
                        preTreeNode.Right = current;

                    preTreeNode = current;
                    current = current.Right;
                }
            }
            return head;
        }

        public void Delete(int key)
        {
            // 1. leaf node
            Node<T> target = Find(key);
            if(target != null && target != root)
            {
                if(current.Left == null && current.Right == null)
                {
                    if (parent.Left == current)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }
                // 2. have one node
                else if (current.Left == null && current.Right != null)
                {
                    if (parent.Right == current)
                        parent.Right = current.Right;
                    else
                        parent.Left = current.Right;
                }
                else if(current.Left != null && current.Right == null)
                {
                    if (parent.Right == current)
                        parent.Right = current.Left;
                    else
                        parent.Left = current.Left;
                }
                // 3. have two node
                else
                {
                    Node<T> soccessor = current.Right;//后继节点
                    Node<T> soccessorParent = current;//后继节点的父节点
                    while(soccessor.Left != null)
                    {
                        soccessorParent = soccessor;
                        soccessor = soccessor.Left;
                    }
                    if(current == parent.Left)
                    {
                        parent.Left = soccessor;
                        soccessor.Left = current.Left;
                        if (current == soccessorParent)//判断要删除点是否为后继点的父节点
                            current.Right = null;
                        else
                        {
                            soccessor.Right = current.Right;
                            soccessorParent.Left = null;
                        }
                    }
                    //3.2 要删除点是其父节点的右节点
                    else if(current == parent.Right)
                    {
                        parent.Right = soccessor;
                        soccessor.Left = current.Left;
                        if (current == soccessorParent)
                            current.Right = null;
                        else
                        {
                            soccessor.Right = current.Right;
                            soccessorParent.Left = null;
                        }
                    }
                }
            }
            //如果要删除点是根节点，直接删除整棵树
            else if(target == root)
            {
                root = null;
            }
        }

    }
}
