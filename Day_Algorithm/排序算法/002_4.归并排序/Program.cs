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
            int[] arr = {7, 8, 9, 3, 1, 4, 5,78,54,65,98};
            Sort(arr);
            foreach(var a in arr)
                Console.WriteLine(a);
        }

        static void Sort(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Sort(arr, 0, arr.Length - 1, temp);
        }

        static void Sort(int[] arr,int left,int right,int[] temp)
        {
            if (left < right)
            {
                int mid = (left + right)/2;
                Sort(arr, left, mid, temp);
                Sort(arr, mid + 1, right, temp);
                AdjustData(arr, left, mid, right, temp);
            }
        }

        static void AdjustData(int[] arr,int left,int mid,int right,int[] temp)
        {
            int i = left;
            int j = mid + 1;
            int index = 0;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                    temp[index++] = arr[i++];
                else
                    temp[index++] = arr[j++];
            }


            while (i <= mid)
                temp[index++] = arr[i++];

            while (j <= right)
                temp[index++] = arr[j++];

            index = 0;

            while (left <= right)
                arr[left++] = temp[index++];
        }
    }
}
