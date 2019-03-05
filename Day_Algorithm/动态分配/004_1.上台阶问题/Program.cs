using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
有一座高度是10级台阶的楼梯，从下往上走，每跨一步只能向上1级或者2级台阶。要求用程序来求出一共有多少种走法。
 */
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Step(10));
            Console.WriteLine(Step_Noram(10));
        }

        static int Step(int n)
        {
            if (n == 1)
                return 1;

            if (n == 2)
                return 2;

            return Step(n - 1) + Step(n - 2);
        }


        static int Step_Noram(int n)
        {
            if (n == 1)
                return 1;

            if (n == 2)
                return 2;

            int a = 1;
            int b = 2;
            int temp = 0;

            for (int i = 3; i <= n; i++)
            {
                temp = a + b;
                a = b;
                b = temp;
            }

            return temp;
        }

    }
}
