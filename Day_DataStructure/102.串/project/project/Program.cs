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
            string a = "12232312323";
            string b = "123";
            Console.WriteLine(a.IndexOf(b));

            StringDS sd1 = new StringDS("12232312323");
            StringDS sd2 = new StringDS("123");
            Console.WriteLine(sd1.IndexOfByIndex(sd2));
        }
    }
}
