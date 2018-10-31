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
            StringDS a = new StringDS("12234");
            StringDS b = new StringDS("42");

            //Console.WriteLine("比较结果：" + StringDS.Compare(a, b));

            string c = "12234";
            string d = "42";

            
            Console.WriteLine(c.IndexOf(d));
            Console.WriteLine(a.IndexOf(b));
        }
    }
}
