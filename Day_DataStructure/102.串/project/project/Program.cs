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
            string a = "3231/a/s/////";
            string b = "23";
            
            

            StringDS sd1 = new StringDS("3231/a/s/////");
            StringDS sd2 = new StringDS("/");
            Console.WriteLine(sd1.Replace('/', 'u'));
        }
    }
}
