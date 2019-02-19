using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr =
            {
                5,8,9,7,4,1,3,
                3,5,7,5
            };

            Sort(arr);

            foreach(var a in arr)
                Console.WriteLine(a);
        }

        static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        static void Sort(int[] arr,int left,int right)
        {
            if (left >= right)
                return;

            int midIndex = SortAndGetMidIndex(arr, left, right);

            Sort(arr, left, midIndex - 1);
            Sort(arr, midIndex + 1, right);
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
