using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_2
{
    /// <summary>
    /// 快速排序
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 7, 8, 9, 5, 32, 3 };
            Sort(arr);
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
        }

        static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        static void Sort(int[] arr,int left,int right)
        {
            if (left >= right)
                return;

            int mid = AdjustData(arr, left, right);

            Sort(arr, left, mid);
            Sort(arr, mid + 1, right);
        }

        static int AdjustData(int[] arr,int left,int right)
        {
            int baseValue = arr[left];
            while (left < right)
            {
                while (left < right && arr[right] > baseValue)
                    right--;

                arr[left] = arr[right];

                while (left < right && arr[left] <= baseValue)
                    left++;

                arr[right] = arr[left];
            }

            arr[left] = baseValue;
            return left;
        }
    }
}
