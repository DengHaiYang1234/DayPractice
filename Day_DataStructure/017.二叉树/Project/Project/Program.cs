using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> t = new Tree<int>(1);
            t.Insert(2);
            t.Insert(-1);
            t.Insert(3);
            t.Insert(-3);
            t.Insert(-2);
            t.WalkTree();
        }
    }

    public class Tree<TItem> where TItem : IComparable<TItem>
    {
        TItem Nodedata;
        Tree<TItem> LeftTree;
        Tree<TItem> RightTree;

        public Tree(TItem newItem)
        {
            this.Nodedata = newItem;
            this.LeftTree = null;
            this.RightTree = null;
        }

        public void Insert(TItem newTItem)
        {
            TItem currentNodeValue = this.Nodedata;
            Console.WriteLine("currentNodeValue:" + currentNodeValue);
            //CompareTo方法比较的是 value_1与value_2的值
            //若value_1大于value_2   则返回1
            //若value_1等于value_2   则返回0
            //若value_1小于value_2   则返回-1
            if (currentNodeValue.CompareTo(newTItem) > 0)
            {
                if (this.LeftTree == null)
                {
                    this.LeftTree = new Tree<TItem>(newTItem);
                }
                else
                {
                    this.LeftTree.Insert(newTItem);
                }
            }
            else
            {
                if (this.RightTree == null)
                {
                    this.RightTree = new Tree<TItem>(newTItem);
                }
                else
                {
                    this.RightTree.Insert(newTItem);
                }
            }
        }

        public void WalkTree()
        {
            if(this.LeftTree != null)
            {
                this.LeftTree.WalkTree();
            }

            Console.WriteLine(this.Nodedata.ToString());

            if(this.RightTree != null)
            {
                this.RightTree.WalkTree();
            }
        }
    }

}
