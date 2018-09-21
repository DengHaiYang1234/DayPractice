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



            Console.WriteLine("The min is: {0}", bst.Min());
            Console.WriteLine("The max is: {0}", bst.Max());
            Console.Write("Find \"100\": ");
            Console.Write(bst.Find(100).Data + "\n");

            Console.WriteLine("\n" + "PreOrder: ");
            bst.PreOrder(bst.root);
            Console.WriteLine("\n" + "PostOrder:");
            bst.PostOrder(bst.root);
            Console.WriteLine("\n" + "InOrder: ");
            bst.InOrder(bst.root);

            bst.Delete(33);
            Console.WriteLine("\n" + "InOrder: ");
            bst.InOrder(bst.root);

            //Console.WriteLine("---------------------------------------------------");
            //Console.WriteLine("Max:" + bst.Max());
            //Console.WriteLine("Min:" + bst.Min());
            //Console.WriteLine("---------------------------------------------------");
            //Console.WriteLine("Find:" + bst.Find(33).Data);
            //bst.Insert(22);
            //bst.Insert(23);
            //Console.WriteLine("中序:\n");
            //bst.InOrder(bst.root);

            //Console.WriteLine("总节点：" + bst.GetNodeNum(bst.root));

            //Console.WriteLine("深度：" + bst.GetDepth(bst.root));

            ////bst.LevelTraverse(bst.root);

            //Console.WriteLine("求第3层的节点总数：" + bst.GetNodeNumKthLevel(bst.root,3));
            //int height = 0;
            //Console.WriteLine("是否是平衡二叉树：" + bst.IsAVL(bst.root,out height));
            //Console.WriteLine("是否是平衡二叉树Height：" +  height);

            //bst.Mirror(bst.root); //镜像二叉树

            //bst.Convert(bst.root, bst.Find(1), bst.Find(100));

            #region 转换为双链表START
            //Console.WriteLine("-------------------转换为双链表START-------------");
            //Node<int> temp = bst.root;
            //Node<int> head = BinaryTree<int>.convertBalanceTreeToDoubleList(temp);
            ////Node<int> head = BinaryTree<int>.convertBalanceTreeToDoubleListRecursion(temp);
            //Node<int> temp1 = head;
            //Node<int> temp2 = head;

            //Console.WriteLine("-------------------Left-------------");
            //while (temp2.Left != null)
            //{
            //    Console.WriteLine("Data:" + temp2.Data);
            //    temp2 = temp2.Left;
            //}
            //Console.WriteLine("Data:" + temp2.Data);
            //Console.WriteLine("-------------------END-------------");
            //Console.WriteLine("-------------------Right-------------");
            //while (temp1.Right != null)
            //{
            //    Console.WriteLine("Data:" + temp1.Data);
            //    temp1 = temp1.Right;
            //}
            //Console.WriteLine("Data:" + temp1.Data);
            //Console.WriteLine("-------------------END-------------");


            //Console.WriteLine("-------------------转换为双链表END-------------");
            #endregion
            Console.ReadKey();
        }
    }
}
