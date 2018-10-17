using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bst = new BinaryTree();
            bst.Insert(25);
            bst.Insert(50);
            bst.Insert(15);
            bst.Insert(33);
            bst.Insert(4);
            //bst.Insert(100);
            //bst.Insert(20);
            //bst.Insert(38);
            //bst.Insert(1);
            //bst.Insert(10);
            //bst.Insert(18);
            //bst.Insert(30);
            //bst.Insert(32);

            //Console.WriteLine("-----------------递归------------------");
            //Console.WriteLine("\n" + "PreOrder: ");
            //bst.PreSort(bst.root);
            //Console.WriteLine("\n" + "PostOrder:");
            //bst.PostSort(bst.root);
            //Console.WriteLine("\n" + "InOrder: ");
            //bst.InSort(bst.root);

            //Console.WriteLine("---------------非递归------------------");
            //Console.WriteLine("\n" + "PreSortByNoram: ");
            //bst.PreSortByNoram(bst.root);
            //Console.WriteLine("\n" + "PostOrder:");
            //bst.PostSortByNoram(bst.root);
            //Console.WriteLine("\n" + "InOrder: ");
            bst.InSortByNoram(bst.root);

            //Console.WriteLine("Min:" + bst.Min());
            //Console.WriteLine("Max:" + bst.Max());
            //Console.WriteLine("Find:" + bst.Find(10).Data);
            //Console.WriteLine("NodeNum:" + bst.GetNodeNumByNoram());
            //Console.WriteLine("Depth:" + bst.Depth(bst.root));


            //bst.LevelTraverse(bst.root);
            //Console.WriteLine("第一层的节点数:" + bst.GetNodeNumByK_Level(2,bst.root));
        }
    }
}
