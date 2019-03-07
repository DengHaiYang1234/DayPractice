using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
求众数
给定一个大小为 n 的数组，找到其中的众数。众数是指在数组中出现次数大于 ⌊ n/2 ⌋ 的元素。

你可以假设数组是非空的，并且给定的数组总是存在众数。
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 2, 1, 1, 1, 2, 2,5,5,5,5,5,55,5,5,5,5,5,5,5,5,2,2,2,2,1,1,1 };
            Console.WriteLine(Solution(nums));
        }

        static int Solution(int[] nums)
        {
            int count = 1;
            int baseValue = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (baseValue == nums[i])
                    count++;
                else
                {
                    count--;
                    if (count == 0)
                    {
                        baseValue = nums[i + 1];
                    }
                }
            }

            return baseValue;
        }
    }
}
