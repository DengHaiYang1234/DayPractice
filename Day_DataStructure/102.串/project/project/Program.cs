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
            string a = "3231";
            string b = "23";
            Console.WriteLine(a.IndexOf(b));

            StringDS sd1 = new StringDS("3231");
            StringDS sd2 = new StringDS("23");
            Console.WriteLine(sd1.IndexOfByKMP(sd2));
        }
    }
}
