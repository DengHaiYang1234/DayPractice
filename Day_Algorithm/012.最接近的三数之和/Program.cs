using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
给定一个包括 n 个整数的数组 nums 和 一个目标值 target。找出 nums 中的三个整数，使得它们的和与 target 最接近。返回这三个数的和。假定每组输入只存在唯一答案。

例如，给定数组 nums = [-1，2，1，-4], 和 target = 1.

与 target 最接近的三个数的和为 2. (-1 + 2 + 1 = 2).
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {-1, 2, 1, -4};
            Sort(nums, 0, nums.Length - 1);
            Console.WriteLine(ThreeSumClosest(nums,1));
        }

        static int ThreeSumClosest(int[] nums, int target)
        {
            int value = nums[0] + nums[1] + nums[2];

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum > target) //大于预期值
                    {
                        right--;
                    }
                    else if (sum < target)//小于预期值
                        left++;
                    else
                        return sum; //等于预期值

                    //若当前预期值小于保存的预期值  那么就去小的预期值
                    value = Math.Abs(sum - target) > Math.Abs(value - target) ? value : sum;
                }
            }
            return value;
        }



        static void Sort(int[] arr,int startIndex,int endIndex)
        {
            if (startIndex >= endIndex)
                return;

            int midIndex = SortAndGetMidIndex(arr, startIndex, endIndex);
            Sort(arr, startIndex, midIndex - 1);
            Sort(arr, midIndex + 1, endIndex);
        }

        static int SortAndGetMidIndex(int[] arr,int startIndex,int endIndex)
        {
            int baseValue = arr[startIndex];
            while (startIndex < endIndex)
            {
                while (startIndex < endIndex && baseValue < arr[endIndex]) //找小
                    endIndex--;
                arr[startIndex] = arr[endIndex];

                while (startIndex < endIndex && baseValue >= arr[startIndex])//找大
                    startIndex++;
                arr[endIndex] = arr[startIndex];
            }

            arr[startIndex] = baseValue;
            return startIndex;
        }
    }
}
