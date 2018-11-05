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

    }
}
