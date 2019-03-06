using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
合并两个有序数组
给定两个有序整数数组 nums1 和 nums2，将 nums2 合并到 nums1 中，使得 num1 成为一个有序数组。

说明:

初始化 nums1 和 nums2 的元素数量分别为 m 和 n。
你可以假设 nums1 有足够的空间（空间大小大于或等于 m + n）来保存 nums2 中的元素。
示例:

输入:
nums1 = [1,2,3,0,0,0], m = 3
nums2 = [2,5,6],       n = 3

输出: [1,2,2,3,5,6]
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2, 3, 8, 11, 555 };
            int[] nums2 = { 2, 5, 6,7 };

            int[] newNums = Solution(nums1,5,nums2,3);

            foreach(var i in newNums)
                Console.WriteLine(i);
        }


        static int[] Solution(int[] nums1,int m,int[] nums2,int n)
        {
            int i = 0;

            int j = 0;

            int index = 0;

            int[] newNums = new int[m + n];

            while (i < m && j < n)
            {
                if (nums1[i] < nums2[j])
                {
                    newNums[index++] = nums1[i++];
                }
                else
                    newNums[index++] = nums2[j++];
            }

            while (i < m)
                newNums[index++] = nums1[i++];

            while (j < n)
                newNums[index++] = nums2[j++];

            return newNums;
        }

    }
}
