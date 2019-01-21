using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
在最差情况下，划分由 n 个元素构成的数组需要进行 n 次比较和 n 次移动。因此划分所需时间为 O(n) 。最差情况下，每次主元会将数组划分为一个大的子数组和一个空数组。这个大的子数组的规模是在上次划分的子数组的规模减 1 。该算法需要 (n-1)+(n-2)+…+2+1= O(n^2) 时间。 
在最佳情况下，每次主元将数组划分为规模大致相等的两部分。设 T(n) 表示使用快速排序算法对包含 n 个元素的数组排序所需的时间，因此，和归并排序的分析相似，快速排序的 T(n)= O(nlogn)。
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1,5,6,7,4,7,8,1,2,5,4,654,45};
            Sort(arr, 0, arr.Length - 1);
            for(int i = 0; i < arr.Length;i++)
                Console.WriteLine(arr[i]);
        }

        static void Sort(int[] arr,int startIndex,int endIndex)
        {
            if (startIndex >= endIndex)
                return;

            int mid = SortAndGetMidIndex(arr, startIndex, endIndex);
            Sort(arr, startIndex, mid - 1);
            Sort(arr, mid + 1, endIndex);
        }

        static int SortAndGetMidIndex(int[] arr, int startIndex, int endIndex)
        {
            int baseValue = arr[startIndex];
            while (startIndex < endIndex)
            {
                //从右至左  找小
                while (startIndex < endIndex && arr[endIndex] > baseValue)
                    endIndex--;
                arr[startIndex] = arr[endIndex];

                while (startIndex < endIndex && arr[startIndex] <= baseValue)
                    startIndex++;
                arr[endIndex] = arr[startIndex];
            }
            arr[startIndex] = baseValue;
            return startIndex;
        }
    }
}
