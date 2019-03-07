using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
乘积最大子序列
给定一个整数数组 nums ，找出一个序列中乘积最大的连续子序列（该序列至少包含一个数）。

示例 1:

输入: [2,3,-2,4]
输出: 6
解释: 子数组 [2,3] 有最大乘积 6。
示例 2:

输入: [-2,0,-1]
输出: 0
解释: 结果不能为 2, 因为 [-2,-1] 不是子数组。
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1,2,3,4,5,6,7};
            Console.WriteLine(Solution(nums));
        }

        static int Solution(int[] nums)
        {
            if (nums.Length < 2)
            {
                return - 1;
            }

            int i = 0;
            int j = i + 1;
            int value = nums[i++]*nums[j++];

            while (j < nums.Length)
            {
                int currentValue = nums[i++]*nums[j++];
                if (currentValue > value)
                {
                    value = currentValue;
                }
            }

            return value;
        }
    }
}
