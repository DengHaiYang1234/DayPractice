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
    }
}
