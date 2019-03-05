using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
题目：一只青蛙一次可以跳上1级台阶，也可以跳上2级……它也可以跳上n级。求该青蛙跳上一个n级的台阶总共有多少种跳法。

    思路：分析可知：如果要上n阶台阶，拥有的可能方法数目是：

f(n)=f(n-1)+f(n-2)+f(n-3)+……f(1)+f(0);

于是从前往后计算出各个项的值就可以，在简单台阶问题中需要保留2个计算结果供后面的计算使用，这里需要保留每一项的计算结果，可以使用一个数组来保存dp[i]，但是进一步分析发现可知：

f(n)=f(n-1)+f(n-2)+f(n-3)+……f(1)+f(0);

f(n-1)=f(n-2)+f(n-3)+……f(1)+f(0);

即f(n)=2*f(n-1)；

于是只要保留1项结果就可以了，再分析初始值，

f(0)=1;

f(1)=1;

f(2)=2;……

于是f(n)=2^(n-1);
 */
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Count(6));
            Console.WriteLine(GetCount(6));
            Console.WriteLine(GetCountDP(6));
        }

        static int Count(int n)
        {
            if (n == 1)
                return 1;

            return 2 * Count(n - 1);
        }


        static int GetCount(int n)
        {
            int sum = 0;
            if (n == 1)
                return 1;
            else
            {
                for (int i = 1; i < n; i++)
                    sum += GetCount(i);

                sum += 1;
            }

            return sum;
        }


        static int GetCountDP(int n)
        {
            if (n == 1)
                return 1;

            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;


            for (int i = 2; i <= n; i++)
            {
                dp[i] = 0;
                for (int j = 0; j < i; j++)
                {
                    dp[i] += dp[j];
                }

            }

            return dp[n];
        }

    }
}
