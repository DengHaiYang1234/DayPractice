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
            LinkList<int> a = new LinkList<int>();
            a.Add(1);
            a.Add(18);
            a.Add(89);
            //a.Remove(18);
            a.Add(55);
            a.Add(56);
            a.Add(33);
            a.Add(66);
            a.Add(55); 
            //a.Add(55);
            //a.Add(55);
            //a.Insert(2, 6666);
            //a.Insert(0, 1111);
            //Console.WriteLine("index:" + a.IndexOf(55));

            int step = 0;
            Node<int> node = a.CycleInfo(out step);
            if (node != null)
            {
                Console.WriteLine("相交点:" + node.Data);
                Console.WriteLine("环长：" + step);
            }
            else
            {
                Console.WriteLine("空!");
            }


            Console.WriteLine("---------------SeqList-------------");
            for (int i = 0; i < a.GetLength(); i++)
                Console.WriteLine(a[i]);
        }
    }
}
