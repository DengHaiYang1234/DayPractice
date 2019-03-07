using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
存在重复元素

给定一个整数数组，判断是否存在重复元素。

如果任何值在数组中出现至少两次，函数返回 true。如果数组中每个元素都不相同，则返回 false。

示例 1:

输入: [1,2,3,1]
输出: true
示例 2:

输入: [1,2,3,4]
输出: false
示例 3:

输入: [1,1,1,3,3,4,3,2,4,2]
输出: true
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1,8,9,36,3,5,6,3};
            Sort(arr);


            Console.WriteLine(Solution(arr));
        }

        static bool Solution(int[] arr)
        {
            int i = 0;
            int j = i + 1;

            int[] indexs = new int[2];

            while (j < arr.Length)
            {
                if (arr[i++] == arr[j++])
                {
                    return true;
                }
            }
            return false;
        }


        static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        static void Sort(int[] arr,int start,int end)
        {
            if (start >= end)
                return;

            int mid = Merage(arr, start, end);

            Sort(arr, start, mid - 1);
            Sort(arr, mid + 1, end);
        }

        static int Merage(int[] arr,int start,int end)
        {
            int baseValue = arr[start];

            while (start < end)
            {
                while (start < end && arr[end] > baseValue)
                    end--;

                arr[start] = arr[end];

                while (start < end && arr[start] <= baseValue)
                    start++;

                arr[end] = arr[start];
            }

            arr[start] = baseValue;

            return start;
        }

        
    }
}
