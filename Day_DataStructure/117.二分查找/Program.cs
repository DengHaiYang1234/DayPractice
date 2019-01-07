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
            int[] arr = new int[] {1, 5, 9, 3, 5, 8, 50};
            int index = BinarySearch(arr, 8);
            Console.WriteLine(index);
        }

        static int BinarySearch(int[] arr,int value)
        {
            int low = 0;
            int high = arr.Length - 1;
            while (low <= high)
            {
                int mid = (low + high)/2;
                if (arr[mid] == value)
                    return mid;

                if (value > arr[mid])
                {
                    low = mid + 1;
                }
                else
                    high = mid - 1;
            }

            return -1;
        }
    }
}
