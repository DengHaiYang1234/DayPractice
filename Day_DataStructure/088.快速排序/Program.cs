﻿using System;
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
            int[] arr = new int[] {4, 8, 5, 2, 1, 5, 2, 3, 78, 98, 32, 5123, 564, 21, 5456};

            OrderByNoram(arr);

            foreach(var value in arr)
                Console.WriteLine(value);
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

        static void OrderByNoram(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[i] > arr[j])
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
