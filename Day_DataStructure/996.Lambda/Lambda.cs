using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> func = new Func<int, int, int>((a,b) =>
            {
                return a + b;
            });

            int result = func(100, 200);
            Console.WriteLine(result);

            func = (x,y) =>
            {
                return x * y;
            };

            result = func(3, 10);

            Console.WriteLine(result);
        }



    }


}
