using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {3,1,1,8,9};

            Sort(arr, 0, arr.Length - 1);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void Sort(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
                return;

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
                    endIndex--;

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
