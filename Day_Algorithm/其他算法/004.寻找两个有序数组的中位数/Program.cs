﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

给定两个大小为 m 和 n 的有序数组 nums1 和 nums2。

请你找出这两个有序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。

你可以假设 nums1 和 nums2 不会同时为空。

示例 1:

nums1 = [1, 3]
nums2 = [2]

则中位数是 2.0
示例 2:

nums1 = [1, 2]
nums2 = [3, 4]

则中位数是 (2 + 3)/2 = 2.5

*/
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = new int[] { 1, 2 ,5};
            int[] nums2 = new int[] { 3, 4 };
            double value = FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine("中位数：" + value);
        }

        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] newArr = Merge(nums1, nums2);
            double midValue = 0.0;
  
            Sort(newArr, 0, newArr.Length - 1);

            if (newArr.Length%2 == 0)
            {
                int midIndex_1 = newArr.Length/2;
                int midIndex_2 = midIndex_1 - 1;
                midValue = (double)(newArr[midIndex_1] + newArr[midIndex_2])/2;
            }
            else if(newArr.Length %2 == 1)
            {
                double midIndex = Math.Ceiling((double)(newArr.Length/2));
                midValue = newArr[(int)midIndex];
            }

            return midValue;
        }

        static int[] Merge(int[] nums1, int[] nums2)
        {
            int len = nums1.Length + nums2.Length;
            int[] newArr = new int[len];
            int index = 0;

            while (index < len)
            {
                if (index < nums1.Length)
                {
                    newArr[index] = nums1[index];
                }
                else if (index < len)
                {
                    newArr[index] = nums2[nums2.Length - (len - index)];
                }
                index++;
            }

            return newArr;
        }


        static void Sort(int[] arr,int startIndex,int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int midIndex = SortAndGetMidIndex(arr, startIndex, endIndex);
            Sort(arr, startIndex, midIndex - 1);
            Sort(arr, midIndex + 1, endIndex);
        }


        static int SortAndGetMidIndex(int[] arr,int startIndex,int endIndex)
        {
            int baseValue = arr[startIndex];
            while (startIndex < endIndex)
            {
                while (startIndex < endIndex && baseValue < arr[endIndex])
                    endIndex --;

                arr[startIndex] = arr[endIndex];

                while (startIndex < endIndex && baseValue >= arr[startIndex])
                    startIndex++;

                arr[endIndex] = arr[startIndex];
            }

            arr[startIndex] = baseValue;
            return startIndex;
        }
    }
}
