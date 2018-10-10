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
            StringDS a = new StringDS("123234456");
            StringDS b = new StringDS("12232344");
            Console.WriteLine("结果:" + a.IndexOf(b));

            //StringDS c = new StringDS("122323442");
            
            //Console.WriteLine(c.Remove(3));

            string ad = "1223asd";
            Console.WriteLine(ad.Substring(3));

            StringDS c = new StringDS("1223asd");
            Console.WriteLine(c.SubString(3));
        }
    }
}
