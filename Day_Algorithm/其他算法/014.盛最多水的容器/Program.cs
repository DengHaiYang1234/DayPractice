using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
给定 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0)。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。
示例:

输入: [1,8,6,2,5,4,8,3,7]
输出: 49

*/
namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] arr = new int[] {1, 8, 6, 2, 5, 4, 8, 3, 7};
            Console.WriteLine(maxArea(arr));
        }

        public static int maxArea(int[] a)
        {
            if (a.Length <= 1)
                return -1;

            int i = 0;
            int j = a.Length - 1;
            int max = 0;

            while (i < j)
            {
                int h = Math.Min(a[i],a[j]); //获取当前高
                max = Math.Max(max,h * (j - i)); //底乘以高  求的面积
                if (a[i] < a[j])
                    i++;
                else
                    j--;
            }

            return max;
        }
    }
}
