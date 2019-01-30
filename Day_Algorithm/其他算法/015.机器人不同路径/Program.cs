using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
一个机器人位于一个 m x n 网格的左上角 。

机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角。

问总共有多少条不同的路径？

说明：m 和 n 的值均不超过 100。

动态分配
思路：例如3 X 2方格。若机器人走到（1，1），那么需要先通过（0，1）或者（1，0）才走到（1，1），所以有两种方式，依次往后类推。
*/
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(_UniquePaths(7,3));
        }

        public static int UniquePaths(int m, int n)
        {
            int[,] dp = new int[m,n];
            for (int i = 0; i < m; i++) //行
            {
                for (int j = 0; j < n; j++) //列
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 1;
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }
            return dp[m - 1, n - 1];//终点
        }

        public static int _UniquePaths(int m, int n)
        {
            int[,] map = new int[m, n];
            for (int i = 0; i < m; i++) //行
            {
                for (int j = 0; j < n; j++) //列
                {
                    if (i == 0 || j == 0)
                    {
                        map[i, j] = 1;
                    }
                    else
                    {
                        map[i, j] = map[i - 1, j] + map[i, j - 1];
                    }
                }
            }

            return map[m - 1, n - 1];
        }
    }
}
