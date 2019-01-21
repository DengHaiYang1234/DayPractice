using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peoject
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDS a = new StringDS("123234456");
            StringDS b = new StringDS("44");
            Console.WriteLine(a.IndexOfByKMP(b));
        }
    }
}
