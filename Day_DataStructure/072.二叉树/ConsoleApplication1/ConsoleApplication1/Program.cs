using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
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

            //Console.WriteLine("\n" + "PreOrder: ");
            //bst.PreSort(bst.root);
            //Console.WriteLine("\n" + "MidSort:");
            //bst.MidSort(bst.root);
            //Console.WriteLine("\n" + "LastSort: ");
            //bst.PostSort(bst.root);

            //Console.WriteLine("\n" + "PostSortByNoram: ");
            //bst.PostSortByNoram(bst.root);

            //Console.WriteLine("Min：" + bst.Min(bst.root).Data);
            //Console.WriteLine("Max：" + bst.Max(bst.root).Data);

            //Console.WriteLine("Find：" + bst.Find(100).Data);

            //Console.WriteLine("K:" + bst.GetNodeNumBy_KLevel(4,bst.root));

            //bst.LevelTraverse(bst.root);

            //int height;

            //Console.WriteLine("IsAVL:" + bst.IsAVL(bst.root, out height));
            //Console.WriteLine("height:" + height);

            Node head = BinaryTree.ConverBalanceTreeDoubleList(bst.root);

            while (head != null)
            {
                Console.WriteLine(head.Data);
                head = head.Right;
            }
        }
    }
}
