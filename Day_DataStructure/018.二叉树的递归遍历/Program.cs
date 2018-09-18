using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    [DebuggerDisplay("Value = {Value}")]
    public class Tree
    {
        public string Value;
        public Tree Left;
        public Tree Right;


        public static Tree CreatFakeTree()
        {
            Tree tree = new Tree() { Value = "A" };
            tree.Left = new Tree()
            {
                Value = "B",
                Left = new Tree() { Value = "D", Left = new Tree() { Value = "G" } },
                Right = new Tree() { Value = "E", Right = new Tree() { Value = "H" } }
            };

            tree.Right = new Tree() { Value = "C", Right = new Tree() { Value = "F" } };
            return tree;
        }

        //先序遍历
        public static void PreOrder(Tree tree)
        {
            if(tree == null)
            {
                return;
            }

            Console.WriteLine(tree.Value);
            PreOrder(tree.Left);
            PreOrder(tree.Right);
        }
        //中序遍历
        public static void MidOrder(Tree tree)
        {
            if (tree == null)
                return;

            MidOrder(tree.Left);
            Console.WriteLine(tree.Value);
            MidOrder(tree.Right);
        }
        //后序遍历
        public static void LastOrder(Tree tree)
        {
            if (tree == null)
                return;
            LastOrder(tree.Left);
            LastOrder(tree.Right);
            Console.WriteLine(tree.Value);
        }
    }

    public class Project
    {
        static void Main()
        {
           Tree tree =  Tree.CreatFakeTree();
           Tree.LastOrder(tree);
        }
    }



   

}
