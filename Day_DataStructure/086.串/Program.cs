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
            StringDS a1 = ",2,3";

            StringDS[] sds =  a1.Split(',');

            foreach(var i in sds)
                Console.WriteLine(i);

            //string b1 = "123123123";
            //string b2 = "123";
            //Console.WriteLine("string:" + b1.Remove(3,5));
        }
    }
}
