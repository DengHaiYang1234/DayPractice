using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
递增的三元子序列

给定一个未排序的数组，判断这个数组中是否存在长度为 3 的递增子序列。

数学表达式如下:

如果存在这样的 i, j, k,  且满足 0 ≤ i < j < k ≤ n-1，
使得 arr[i] < arr[j] < arr[k] ，返回 true ; 否则返回 false 。
说明: 要求算法的时间复杂度为 O(n)，空间复杂度为 O(1) 。

示例 1:

输入: [1,2,3,4,5]
输出: true
示例 2:

输入: [5,4,3,2,1]
输出: false

*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] index;
            int[] nums = { 1,5,6,8,9,10,66,6};

            Console.WriteLine(Solution(nums,out index));

            if (index != null)
            {
                foreach (var i in index)
                    Console.WriteLine(nums[i]);
            }

        }

        static bool Solution(int[] nums,out int[] index)
        {
            int i = 0;
            int j = i + 1;
            int k = j + 1;

            while (k < nums.Length)
            {
                if (nums[k] - nums[j] == nums[j] - nums[i])
                {
                    index = new int[] {i, j, k};
                    
                    return true;
                }
                else
                {
                    i++;
                    j++;
                    k++;
                }
            }

            index = null;

            return false;
        }
    }
}
