using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 因为n为整数，所以每个步骤找零差值为1元，即：
求兑换n元的最小硬币，可以先求兑换n-1元最少硬币数量
求兑换n-1元，要先求兑换n-2元
拆分成如下：
1、兑换0元（为了方便，所以从0开始）最少硬币数量
2、兑换1元最少硬币数量
3、兑换2元最少硬币数量
n+1、兑换n元最少硬币数量
设数组dp[n],且 dp[i] 为兑换 i 元所用最少硬币数量（所以要从0开始，dp[0]是兑换0元的最少硬币数量，多么直观啊）
 */
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = {1,2,5};
            Console.WriteLine(Change(coins,5));
        }

        static int Change(int[] coins,int amount)
        {
            int[] dp = new int[amount + 1];

            for (int i = 1; i < dp.Length; i++)
                dp[i] = amount + 1;

            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }

    }
}
