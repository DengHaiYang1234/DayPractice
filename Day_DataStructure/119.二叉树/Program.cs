﻿using System;
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
            //Console.WriteLine("\n" + "MidSort:");
            //bst.MidSort(bst.root);
            //Console.WriteLine("\n" + "PostSort: ");
            //bst.PostSort(bst.root);

            //Console.WriteLine("-----------------非递归------------------");
            //Console.WriteLine("\n" + "PreOrder: ");
            //bst.PreSortByNoram(bst.root);
            //Console.WriteLine("\n" + "MidSort:");
            //bst.MidSortByNoram(bst.root);
            //Console.WriteLine("\n" + "LastSort: ");
            //bst.PostSortByNoram(bst.root);


            //Console.WriteLine("-----------------层序------------------");
            //bst.SequenceSort(bst.root);.


            //Console.WriteLine("-----------------删除------------------");
            //bst.Delete(25);
            //Console.WriteLine("\n" + "LastSort:");
            //bst.PostSortByNoram(bst.root);

            Console.WriteLine("-----------------转换链表------------------");
            Node head =  bst.ConversionToLinkList(bst.root);


            while (head != null)
            {
                Console.WriteLine(head.Data);
                head = head.Right;
            }
        }
    }
}
