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
            StringDS a = new StringDS("12,23,4789");
            StringDS b = new StringDS("42");

            //Console.WriteLine("比较结果：" + StringDS.Compare(a, b));

            string c = "12,23,4789";
            string d = "42";


            string[] ts = c.Split(',');


            for(int i = 0; i< ts.Length;i++)
                Console.WriteLine(ts[i]);


            StringDS[] ds = a.Split(',');
            Console.WriteLine("-----------------------------------------");
            for (int i = 0; i < ds.Length; i++)
                Console.WriteLine(ds[i]);


            //Console.WriteLine(c.Split(','));



            //Console.WriteLine(a.Substring(2,3));
        }
    }
}
