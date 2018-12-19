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
            int[] nums = new int[] {4, 5, 7, 8, 9, 3, 1, 4, 5, 5};
            FindByMap(nums, 8);
        }

        /// <summary>
        /// o(n2)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        static void Find(int[] nums,int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int surplusNum = target - nums[i];

                for (int j = nums.Length - 1; j > i; j--)
                {
                    if (nums[j] == surplusNum)
                    {
                        Console.WriteLine("下标索引1：" + i);
                        Console.WriteLine("下标索引2：" + j);
                        return;
                    } 
                }
            }
        }

        /// <summary>
        /// o(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        static void FindByMap(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                map[nums[i]] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int surplusNum = target - nums[i];
                if (map.ContainsKey(surplusNum))
                {
                    Console.WriteLine("下标索引1：" + i);
                    Console.WriteLine("下标索引2：" + map[surplusNum]);
                    return;
                }
            }
        }
    }
}
