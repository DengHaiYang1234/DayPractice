using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
两个数组的交集 II
给定两个数组，编写一个函数来计算它们的交集。

示例 1:

输入: nums1 = [1,2,2,1], nums2 = [2,2]
输出: [2,2]
示例 2:

输入: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
输出: [4,9]
说明：

输出结果中每个元素出现的次数，应与元素在两个数组中出现的次数一致。
我们可以不考虑输出结果的顺序。
进阶:

如果给定的数组已经排好序呢？你将如何优化你的算法？
如果 nums1 的大小比 nums2 小很多，哪种方法更优？
如果 nums2 的元素存储在磁盘上，磁盘内存是有限的，并且你不能一次加载所有的元素到内存中，你该怎么办？

*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };

            int[] arr = Solution(nums1, nums2);

            foreach(var i in arr)
                Console.WriteLine(i);
        }

        static int[] Solution(int[] nums1,int[] nums2)
        {
            Sort(nums1);
            Sort(nums2);

            int i = 0;
            int j = 0;

            int len = nums1.Length > nums2.Length ? nums1.Length : nums2.Length;

            int[] arr = new int[len];

            int index = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                    i++;
                else if (nums1[i] == nums2[j])
                {
                    arr[index++] = nums1[i];
                    i++;
                    j++;
                }
                else
                    j++;
            }

            return arr;
        }
        
        static void Sort(int[] arr)
        {
            for (int i = (arr.Length - 1)/2; i >= 0; i--)
            {
                AdjustHeap(arr, i, arr.Length - 1);
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                AdjustHeap(arr, 0, i);
            }
        }

        static void AdjustHeap(int[] arr,int i,int length)
        {
            int baseVale = arr[i];
            int k = i*2 + 1;

            while (k < length)
            {
                if (k + 1 < length && arr[k] < arr[k + 1])
                {
                    k++;
                }
                
                if (arr[k] > baseVale)
                {
                    arr[i] = arr[k];
                    i = k;
                }
                else
                    break;
                k = k*2 + 1;
            }

            arr[i] = baseVale;
        }

        static void Swap(int[] arr,int a,int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
