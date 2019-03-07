using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
旋转数组
给定一个数组，将数组中的元素向右移动 k 个位置，其中 k 是非负数。
示例 1:
输入: [1,2,3,4,5,6,7] 和 k = 3
输出: [5,6,7,1,2,3,4]
解释:
向右旋转 1 步: [7,1,2,3,4,5,6]
向右旋转 2 步: [6,7,1,2,3,4,5]
向右旋转 3 步: [5,6,7,1,2,3,4]
示例 2:
输入: [-1,-100,3,99] 和 k = 2
输出: [3,99,-1,-100]
解释: 
向右旋转 1 步: [99,-1,-100,3]
向右旋转 2 步: [3,99,-1,-100]
说明:
尽可能想出更多的解决方案，至少有三种不同的方法可以解决这个问题。
要求使用空间复杂度为 O(1) 的原地算法。
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -1, -100, 3, 99 };

            Solution(nums, 2);

            foreach(var i in nums)
                Console.WriteLine(i);
        }

        static void Solution(int[] nums,int k)
        {
            while (k > 0)
            {
                int value = nums[nums.Length - 1];
                for (int i = nums.Length - 1; i >= 1; i--)
                {
                    nums[i] = nums[i - 1];
                }

                nums[0] = value;
                k--;
            }

            
        }
    }
}
