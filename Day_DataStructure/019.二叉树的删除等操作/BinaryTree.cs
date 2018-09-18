using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class BinaryTree<T>
    {
        public Node<T> Current;
        Node<T> Parent;
        public Node<T> Root;
        public BinaryTree()
        {
            Root = null;
        }

        public void InOrder(Node<T> theRoot)  //中序遍历
        {
            if(theRoot != null)
            {
                InOrder(theRoot.Left);
                Console.WriteLine(theRoot.Data);
                InOrder(theRoot.Right);
            }
        }

        public void PreOrder(Node<T> theRoot) //先序
        {
            if(theRoot != null)
            {
                Console.WriteLine(theRoot.Data);
                PreOrder(theRoot.Left);
                PreOrder(theRoot.Right);
            }
        }

        public void PostOrder(Node<T> theRoot) //后序
        {
            if(theRoot != null)
            {
                PostOrder(theRoot.Left);
                PostOrder(theRoot.Right);
                Console.WriteLine(theRoot.Data);
            }
        }

        public void Insert(int x)
        {
            Node<T> newNode = new Node<T>(x);
            Current = Root;

            if(Root == null)
            {
                Root = newNode;
            }
            else
            {
                while(true)
                {
                    Parent = Current;
                    if(x < Current.Data)
                    {
                        Current = Current.Left;
                        if(Current == null)
                        {
                            Parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        Current = Current.Right;
                        if(Current == null)
                        {
                            Parent.Right = newNode;
                            break;
                        }
                    }
                }
            }

        }

        public int Min()
        {
            Current = Root;
            while (Current.Left != null)
                Current = Current.Left;

            return Current.Data;
        }

        public int Max()
        {
            Current = Root;
            while (Current.Right != null)
                Current = Current.Right;

            return Current.Data;
        }

        public Node<T> Find(int key)
        {
            Current = Root;

            while(Current != null)
            {
                if(key == Current.Data)
                {
                    break;
                }
                if(key < Current.Data)
                {
                    Parent = Current;
                    Current = Current.Left;
                }
                else
                {
                    Parent = Current;
                    Current = Current.Right;
                }
            }
            if (Current == null)
            {
                return null;
            }
            else
                return Current;
        }

        public void Delete(int key)
        {
            Node<T> Target = Find(key);
            if(Target != null && Target != Root)
            {
                if(Current.Left == null && Current.Right == null)
                {
                    if (Parent.Left == Current)
                        Parent.Left = null;
                    else
                        Parent.Right = null;
                }
                else if(Current.Left == null && Current.Right != null)
                {
                    if (Parent.Right == Current)
                        Parent.Right = Current.Right;
                    else
                        Parent.Left = Current.Right;
                }
                else if(Current.Left != null && Current.Right == null)
                {
                    if (Parent.Right == Current)
                        Parent.Right = Current.Right;
                    else
                        Parent.Left = Current.Left;
                }
                else
                {
                    Node<T> soccessor = Current.Right;
                    Node<T> soccessorParent = Current;
                    while(soccessor.Left != null)
                    {
                        soccessorParent = soccessor;
                        soccessor = soccessor.Left;
                    }
                    if(Current == Parent.Left)
                    {
                        Parent.Left = soccessor;
                        soccessor.Left = Current.Left;
                        if (Current == soccessorParent)
                            Current.Right = null;
                        else
                        {
                            soccessor.Right = Current.Right;
                            soccessorParent.Left = null;
                        }
                    }
                    else if(Current == Parent.Right)
                    {
                        Parent.Right = soccessor;
                        soccessor.Left = Current.Left;
                        if (Current == soccessorParent)
                            Current.Right = null;
                        else
                        {
                            soccessor.Right = Current.Right;
                            soccessorParent.Left = null;
                        }
                    }

                }
            }
            else if(Target == Root)
            {
                Root = null;
            }
        }
    }
}
