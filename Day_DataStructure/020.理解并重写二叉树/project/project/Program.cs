using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> bst = new BinaryTree<int>();
            bst.Insert(25);
            bst.Insert(50);
            bst.Insert(15);
            bst.Insert(33);
            bst.Insert(4);
            bst.Insert(100);
            bst.Insert(20);
            bst.Insert(38);
            bst.Insert(1);
            bst.Insert(10);
            bst.Insert(18);
            bst.Insert(30);
            bst.Insert(32);


            Console.WriteLine("先序:\n");
            bst.PreOrder(bst.root);
            Console.WriteLine("中序:\n");
            bst.InOrder(bst.root);
            Console.WriteLine("后序:\n");
            bst.PostOrder(bst.root);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Max:" + bst.Max());
            Console.WriteLine("Min:" + bst.Min());
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Find:" + bst.Find(33).Data);
            bst.Insert(22);
            bst.Insert(23);
            bst.Insert(1);
            Console.WriteLine("中序:\n");
            bst.InOrder(bst.root);

            Console.WriteLine("总节点：" + bst.GetNodeNum(bst.root));

            Console.WriteLine("深度：" + bst.GetDepth(bst.root));

            //bst.LevelTraverse(bst.root);

            Console.WriteLine("求第3层的节点总数：" + bst.GetNodeNumKthLevel(bst.root,3));
        }
    }
}
