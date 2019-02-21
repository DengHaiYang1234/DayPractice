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
            string a = "tretrertert";
            string b = "ert";

            Console.WriteLine(a.IndexOf(b));

            StringDS aa = new StringDS("tretrertert") ;
            StringDS bb = new StringDS("ert");

            Console.WriteLine(aa.IndexOfByKMP(bb));
        }
    }
}
