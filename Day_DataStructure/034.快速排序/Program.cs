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
            int[] arr = new int[] {5, 1, 2, 3, 4, 8, 6, 2, 8, 7, 1, 3, 5, 65, 58, 5};
            Sort(0, arr.Length - 1, arr);
            for(int i = 1; i < arr.Length;i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void Sort(int startIndex,int endIndex,int[] arr)
        {
            if (startIndex >= endIndex)
                return;
            int midIndex = SortAndGetMidIndex(startIndex,endIndex,arr);

            Sort(startIndex, midIndex - 1, arr);
            Sort(midIndex + 1, endIndex, arr);
        }

        static int SortAndGetMidIndex(int leftIndex, int rightIndex, int[] arr)
        {
            int baseValue = arr[leftIndex];
            while(leftIndex < rightIndex)
            {
                //从右往左  找小
                while (leftIndex < rightIndex && baseValue < arr[rightIndex])
                    rightIndex--;
                arr[leftIndex] = arr[rightIndex];

                //从左往右  找大
                while (leftIndex < rightIndex && baseValue >= arr[leftIndex])
                    leftIndex++;
                arr[rightIndex] = arr[leftIndex];
            }

            arr[leftIndex] = baseValue;
            return leftIndex;
        }
    }
}
