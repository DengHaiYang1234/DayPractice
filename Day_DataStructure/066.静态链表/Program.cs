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
            StaticLink ls = new StaticLink();
            Link l1 = new Link() { data = "小花" };
            Link l2 = new Link() { data = "小白" };
            Link l3 = new Link() { data = "小虎" };
            Link l4 = new Link() { data = "小涛" };
            Link l5 = new Link() { data = "小智" };
            ls.Add(l1);
            ls.Add(l2);

            ls.Add(l3);

            foreach (var item in StaticLink.arr)
            {
                Console.WriteLine(string.Format("数据：{0}，游标:{1}", item.data, item.cur));
            }
            Console.WriteLine("--------------------------------------------------------------");
            //ls.Delete(2);
            ls.Insert(2, l4);
            foreach (var item in StaticLink.arr)
            {
                Console.WriteLine(string.Format("数据：{0}，游标:{1}", item.data, item.cur));
            }
            //ls.Insert(1, l1);
            Console.Read();
        }
    }
}
