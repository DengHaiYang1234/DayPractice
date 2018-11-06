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
            BinaryTree bst = new BinaryTree();
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

            Console.WriteLine("-----------------递归------------------");
            //Console.WriteLine("\n" + "PreOrder: ");
            //bst.PreSort(bst.root);
            //Console.WriteLine("\n" + "MidSort:");
            //bst.MidSort(bst.root);
            //Console.WriteLine("\n" + "LastSort: ");
            //bst.LastSort(bst.root);

            //Console.WriteLine("\n" + "PreOrderByNoram: ");
            //bst.PreSortByNoram(bst.root);
            //Console.WriteLine("\n" + "MidSortByNoram: ");
            //bst.MidSortByNoram(bst.root);
            //Console.WriteLine("\n" + "LastSortByNoram: ");
            //bst.LastSortByNoram(bst.root);


            //Console.WriteLine("最小值：" + bst.Min(bst.root));
            //Console.WriteLine("最大值：" + bst.Max(bst.root));

            //Console.WriteLine("找key值：" + bst.Find(18).Data);

            //Console.WriteLine("总结点数：" + bst.GetTotalNodeNum(bst.root));

            //Console.WriteLine("深度：" + bst.Depth(bst.root));

            Console.WriteLine("层序遍历:");
            bst.LevelTraverse(bst.root);
        }
    }
}
