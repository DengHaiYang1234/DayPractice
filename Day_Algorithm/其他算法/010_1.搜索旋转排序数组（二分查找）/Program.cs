using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
假设按照升序排序的数组在预先未知的某个点上进行了旋转。
( 例如，数组 [0,1,2,4,5,6,7] 可能变为 [4,5,6,7,0,1,2] )。
搜索一个给定的目标值，如果数组中存在这个目标值，则返回它的索引，否则返回 -1 。
你可以假设数组中不存在重复的元素。
你的算法时间复杂度必须是 O(log n) 级别。
示例 1:
输入: nums = [4,5,6,7,0,1,2], target = 0
输出: 4
示例 2:
输入: nums = [4,5,6,7,0,1,2], target = 3
输出: -1
注意：算法时间复杂度为O(log n)  应使用二分法
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1,2,3,4,5,6,78 };
            int index = Search_Noram(nums, 3);
            Console.WriteLine(index);
        }

        static int Search(int[] nums,int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right)/2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] >= left)
                {
                    if (nums[mid] > target && nums[left] <= target)
                    {
                        right = mid - 1;
                    }
                    else
                        left = mid + 1;
                }
                else
                {
                    if (nums[mid] > target && nums[left] <= target)
                    {
                        right = mid - 1;
                    }
                    else
                        left = mid + 1;
                }
            }

            return -1;
        }

        static int Search_Noram(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right)/2;

                if (nums[mid] == target)
                    return mid;

                if (target > nums[mid])
                    left = mid + 1;
                else
                    right = mid - 1;


            }

            return -1;
        }
    }
}
