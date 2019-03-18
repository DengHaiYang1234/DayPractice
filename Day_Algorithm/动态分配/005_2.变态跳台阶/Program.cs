using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution(5));
            Console.WriteLine(Solution_1(5));
            Console.WriteLine(Solution_2(5));
        }

        static int Solution(int num)
        {
            if (num == 1)
                return 1;


            return 2*Solution(num - 1);
        }

        static int Solution_1(int num)
        {
            if (num == 1)
                return 1;

            int[] dp = new int[num + 1];

            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= num; i++)
            {
                dp[i] = 0;
                for (int j = 0; j < i; j++)
                {
                    dp[i] += dp[j];
                }
            }

            return dp[num];
        }

        static int Solution_2(int num)
        {
            int sum = 0;
            if (num == 1)
                return 1;
            else
            {
                for (int i = 1; i < num; i++)
                {
                    sum += Solution_2(i);
                }

                sum += 1;
            }

            return sum;
        }
    }
}
