using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。

你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。

示例:

给定 nums = [2, 7, 11, 15], target = 9

因为 nums[0] + nums[1] = 2 + 7 = 9
所以返回 [0, 1]
*/

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {2,7,11,15,5,6,9,8,7,1,2,3,5,4,6};
            int[] arr = GetNums(nums, 19);
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);
        }

        static int[] GetNums(int[] nums,int target)
        {
            int i = 0;
            int j = i + 1;
            int[] indexs = new int[2];

            while (i < nums.Length && j < nums.Length)
            {
                if (nums[i] + nums[j] == target)
                {
                    indexs[0] = i;
                    indexs[1] = j;
                    break;
                }
                else
                {
                    if (++j >= nums.Length)
                    {
                        ++i;
                        j = i + 1;
                    }
                }
            }

            return indexs;
        }
    }
}
