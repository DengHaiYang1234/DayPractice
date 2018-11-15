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
            int[] arr = new int[] {18,5,6,3,4,89,56,47,23,1,58,6,2,56};

            #region 快速排序
            //Sort(arr, 0, arr.Length - 1);
            #endregion

            #region 普通排序
            SortByNoram(arr);
            #endregion
            foreach (var s in arr)
                Console.WriteLine(s);
        }

        static void Sort(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
                return;

            int midIndex = SortAndGetMidIndex(arr, startIndex, endIndex);
            Sort(arr, 0, midIndex - 1);
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

        static void SortByNoram(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
