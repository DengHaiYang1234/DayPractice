using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

有一座高度是10级台阶的楼梯，从下往上走，每跨一步只能向上1级或者2级台阶。要求用程序来求出一共有多少种走法。
*/

namespace project
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(GetCount_(4));
            Console.WriteLine(GetCount(4));
        }

        //o(n^2)
        public static int GetCount(int n)
        {
            if (n == 1)
                return 1;

            if (n == 2)
                return 2;


            return GetCount(n - 1) + GetCount(n - 2);
        }


        //o^1
        public static int GetCount_(int n)
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
