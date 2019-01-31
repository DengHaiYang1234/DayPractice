using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
快速排序
*/
namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {7, 8, 5, 6,};
            Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        static void Sort(int[] arr, int left,int right)
        {
            if (left >= right)
                return;

            int mid = AdjustData(arr, left, right);
            Sort(arr, left, mid - 1);
            Sort(arr, mid + 1, right);
        }

        static int AdjustData(int[] arr,int left,int right)
        {
            int baseValue = arr[left];
            while (left < right)
            {
                while (left < right && baseValue < arr[right])
                    right--;

                arr[left] = arr[right];

                while (left < right && baseValue >= arr[left])
                    left++;

                arr[right] = arr[left];
            }

            arr[left] = baseValue;
            return left;
        }
    }


}
