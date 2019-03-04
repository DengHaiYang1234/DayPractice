using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
大富翁游戏，玩家根据骰子的点数决定走的步数，即骰子点数为1时可以走一步，
点数为2时可以走两步，点数为n时可以走n步。求玩家走到第n步（n<=骰子最大点数且是方法的唯一入参）时，总共有多少种投骰子的方法。

解法描述：假如输入的数据为n，则可能的走法有：先走fun(n-1)步，再走一步；也可以先走fun(n-2) 步，再直接一次性走2步；
还可以先走fun（n-3）步，再一次性走3步...依此论推，可以先走fun(1)步，然后一次性走n-1步；最后一次性走n 步。
*/
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Roll(6));
            Console.WriteLine(RollByDp(6));
        }

        static int Roll(int num)
        {
            int sum = 0;
            if (num == 1)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i < num; i++)
                {
                    sum += Roll(i);
                }

                sum += 1; //直接跳到
            }
            return sum;
        }

        static int RollByDp(int n)
        {
            if (n == 0)
                return 0;

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
