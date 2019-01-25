using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string ddd = Test<int>((a, b) =>
            {
                return a*b;
            }, 100,200);

            Console.WriteLine(ddd);
        }

        static string Test<T>(Func<T, T, T> func, T x, T y)
        {
            T result = func(x, y);
            Console.WriteLine(result);

            return "123";
        }
    }
}
