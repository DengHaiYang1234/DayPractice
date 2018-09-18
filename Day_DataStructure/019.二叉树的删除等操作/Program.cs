using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Project
    {
        static void Main()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(25);
            tree.Insert(50);
            tree.Insert(15);
            tree.Insert(33);
            tree.Insert(4);
            tree.Insert(100);
            tree.Insert(20);
            tree.Insert(38);
            tree.Insert(1);
            tree.Insert(10);
            tree.Insert(18);
            tree.Insert(30);

            Console.WriteLine("The min is: {0}", tree.Min());
            Console.WriteLine("The max is: {0}", tree.Max());
            Console.Write("Find \"100\": ");
            Console.Write(tree.Find(100).Data + "\n");

            Console.WriteLine("\n" + "先序PreOrder: ");
            tree.PreOrder(tree.Root);
            Console.WriteLine("\n" + "后序PostOrder:");
            tree.PostOrder(tree.Root);
            Console.WriteLine("\n" + "中序InOrder: ");
            tree.InOrder(tree.Root);

            tree.Delete(33);
            Console.WriteLine("\n" + "删除后的InOrder:");
            tree.InOrder(tree.Root);

        }
    }





}
