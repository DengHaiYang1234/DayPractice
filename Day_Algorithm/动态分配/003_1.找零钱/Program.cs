using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//找零钱
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = { 1, 2, 5 };
            Console.WriteLine(GetChange(coins,5));
        }

        static int GetChange(int[] coins,int target)
        {
            int[,] dp = new int[coins.Length,target+1];

            for (int i = 0; i < coins.Length; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 0; i <= target; i++)
            {
                if (i%coins[0] == 0)
                {
                    dp[0, i] = 1;
                }
                else
                    dp[0, i] = 0;
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
