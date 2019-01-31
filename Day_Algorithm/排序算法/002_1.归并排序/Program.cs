using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
归并排序
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
            int[] temp = new int[arr.Length];
            Sort(arr, 0, arr.Length - 1, temp);
        }

        static void Sort(int[] arr, int leftIndex, int rightIndex, int[] temp)
        {
            if (leftIndex < rightIndex)
            {
                int mid = (leftIndex + rightIndex)/2;
                Sort(arr, leftIndex, mid - 1,temp);
                Sort(arr, mid + 1, rightIndex, temp);
                AdjustData(arr, leftIndex, mid, rightIndex, temp);
            }
        }

        static void AdjustData(int[] arr,int leftIndex,int midIndex,int rightIndex,int[] temp)
        {
            int index = 0;
            int i = leftIndex;
            int j = midIndex + 1;

            while (i <= midIndex && j <= rightIndex)
            {
                if (arr[i] <= arr[j])
                    temp[index++] = arr[i++];
                else
                    temp[index++] = arr[j++];
            }


            while (i <= midIndex)
                temp[index++] = arr[i++];

            while (j <= rightIndex)
                temp[index++] = arr[j++];

            index = 0;

            while (leftIndex <= rightIndex)
                arr[leftIndex++] = temp[index++];

        }
    }


}
