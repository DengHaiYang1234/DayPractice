using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {8, 5, 6, 9, 7, 1, 0, 35, 9, 8};
            Sort(arr,0,arr.Length -1);

            foreach(var a in arr)
                Console.WriteLine(a);
        }


        static void Sort(int[] arr,int left,int right)
        {
            if (left > right)
                return;

            int mid = SortAndGetMidIndex(arr, left, right);

            Sort(arr, left, mid - 1);
            Sort(arr, mid + 1, right);
        }


        static int SortAndGetMidIndex(int[] arr,int left,int right)
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
