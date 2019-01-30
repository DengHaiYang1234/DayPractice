using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

给定不同面额的硬币和一个总金额。写出函数来计算可以凑成总金额的硬币组合数。假设每一种面额的硬币有无限个。 

 

示例 1:

输入: amount = 5, coins = [1, 2, 5]
输出: 4
解释: 有四种方式可以凑成总金额:
5=5
5=2+2+1
5=2+1+1+1
5=1+1+1+1+1
示例 2:

输入: amount = 3, coins = [2]
输出: 0
解释: 只用面额2的硬币不能凑成总金额3。
示例 3:

输入: amount = 10, coins = [10] 
输出: 1
 

注意:

你可以假设：

0 <= amount (总金额) <= 5000
1 <= coin (硬币面额) <= 5000
硬币种类不超过 500 种
结果符合 32 位符号整数
------------------------------------------------------------------------
动态规划 填表dp[h][n+1],h代表有h种硬币coins[]={1,5,10,20,50,100} ，
           n+1代表要拼目标为0-n
  递推公式 :dp[i][j]=dp[i][j]+dp[i-1][j-k*coins[i]],其中k[0,n/coins[i]].
        解释：使用前i种钱币拼凑面值为j的方法数dp[i][j]= 
        使用前i-1种钱币，使用k个第i种钱币，拼凑面值为j的方法数，
        即使用前i-1种钱币拼凑面值为j的方法数dp[i-1][j-k*coins[i]]
初始化：
上表的第一行dp[0]均为1，表示任意目标，只由面值为1的硬币拼凑，拼凑方法为1；
------------------------------------------------------------------------
*/

namespace project
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[] coins = { 1, 2, 5 };
            Console.WriteLine(Change(coins, 5));
        }


        static int GiveChange(int[] coins, int target)
        {
            int[,] dp = new int[coins.Length, target + 1];

            for (int i = 0; i < coins.Length; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 1; i <= target; i++)
            {
                if (i % coins[0] == 0)
                    dp[0, i] = 1;
                else
                    dp[0, i] = 0;
            }

            for (int i = 1; i < coins.Length; i++) //当前使用的零钱
            {
                for (int j = 1; j <= target; j++) //当前面值
                {
                    int temp = 0;
                    for (int k = 0; k * coins[i] <= j; k++) //使用(i-1)的零钱拼凑出当前(j)的面值
                    {
                        temp += dp[i - 1, j - k * coins[i]];
                    }

                    dp[i, j] = temp;
                }
            }

            return dp[coins.Length - 1, target];
        }


        static int Change(int[] coins,int target)
        {
            int[,] dp = new int[coins.Length, target + 1];


            for (int i = 0; i < coins.Length; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 1; i <= target; i++)
            {
                if (i%coins[0] == 0)
                {
                    dp[0, i] = 1;
                }
                else
                    dp[0, 1] = 0;
            }

            for (int i = 1; i < coins.Length; i++)
            {
                for (int j = 1; j <= target; j++)
                {
                    int temp = 0;

                    for (int k = 0; k*coins[i] <= j; k++)
                    {
                        temp += dp[i - 1, j - k*coins[i]];
                    }

                    dp[i, j] = temp;
                }
            }

            return dp[coins.Length - 1, target];
        }

    }
}
