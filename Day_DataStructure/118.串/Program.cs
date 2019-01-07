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
            string a = "4254123";
            string b = "123";
            Console.WriteLine(a.IndexOf(b));

            StringDS a1 = new StringDS("4254123");
            StringDS a2 = new StringDS("123");
            Console.WriteLine(a1.IndexOf(a2));
        }
    }
}
