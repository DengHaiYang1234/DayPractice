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
            //bst.Insert(100);
            //bst.Insert(20);
            //bst.Insert(38);
            //bst.Insert(1);
            //bst.Insert(10);
            //bst.Insert(18);
            //bst.Insert(30);
            //bst.Insert(32);

            Console.WriteLine("-----------------递归------------------");
            //Console.WriteLine("\n" + "PreOrder: ");
            //bst.PreSort(bst.root);
            //Console.WriteLine("\n" + "MidSort:");
            //bst.MidSort(bst.root);
            //Console.WriteLine("\n" + "LastSort: ");
            // bst.PostSort(bst.root);

            //Console.WriteLine("-----------------非递归------------------");
            //Console.WriteLine("\n" + "PreOrder: ");
            //bst.PreSortByNoram(bst.root);
            //Console.WriteLine("\n" + "MidSort:");
            //bst.MidSortByNoram(bst.root);
            //Console.WriteLine("\n" + "LastSort: ");
            //bst.PostSortByNoram(bst.root);


            //Console.WriteLine("-----------------层序遍历------------------");
            //Console.WriteLine("\n" + "SeqSort");
            //bst.SequenceSort(bst.root);


            //Console.WriteLine(bst.Max());
            //Console.WriteLine(bst.Min());

            //Console.WriteLine("TotalNode:" + bst.GetTotalNodeNum(bst.root));

            //Console.WriteLine("GetNodeNumBy_KLevel:" + bst.GetNodeNumBy_KLevel(3,bst.root));
            //bst.Delete(25);
            //Console.WriteLine("-----------------层序遍历------------------");
            //Console.WriteLine("\n" + "SeqSort");
            //bst.SequenceSort(bst.root);


            //Node head = BinaryTree.ConverBalanceTreeDoubleList(bst.root);

            //while (head != null)
            //{
            //    Console.WriteLine(head.Data);
            //    head = head.Right;
            //}

        }
    }
}
