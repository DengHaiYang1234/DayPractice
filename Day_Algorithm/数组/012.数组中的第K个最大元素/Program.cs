using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
数组中的第K个最大元素
在未排序的数组中找到第 k 个最大的元素。请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。

示例 1:

输入: [3,2,1,5,6,4] 和 k = 2
输出: 5
示例 2:

输入: [3,2,3,1,2,4,5,5,6] 和 k = 4
输出: 4
说明:

你可以假设 k 总是有效的，且 1 ≤ k ≤ 数组的长度。
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 2, 1, 5, 6, 4 };
            int maxIndex = Sort(arr, 0, arr.Length - 1,2);

            //foreach (var i in arr)
            //    Console.WriteLine(i);

            Console.WriteLine(arr[maxIndex]);
        }

        static int Sort(int[] arr,int left,int right,int k)
        {
            if (left > right)
                return arr[left];

            int pivotIndex = SortAndGetPivot(arr, left, right); //降序

            int maxIndex = pivotIndex - left + 1; //表示第几大的数

            if (k == maxIndex)
            {
                return pivotIndex;
            }
            else if (maxIndex < k)
            {
                return Sort(arr, pivotIndex + 1, right, k - maxIndex);
            }
            else
            {
                return Sort(arr, left, pivotIndex - 1, k);
            }
        }


        static int SortAndGetPivot(int[] arr,int left,int right)
        {
            int baseValue = arr[left];

            while (left < right)
            {
                while (left < right && baseValue >= arr[right])
                    right--;

                arr[left] = arr[right];

                while (left < right && baseValue < arr[left])
                    left++;

                arr[right] = arr[left];

            }

            arr[left] = baseValue;

            return left;
        }
    }
}
