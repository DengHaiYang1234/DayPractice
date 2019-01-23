using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1
{
    /// <summary>
    /// 归并排序
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 7, 8, 9, 5, 32, 3 };
            Sort(arr);
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
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
                Marge(arr, left, mid, right, temp);
            }
        }

        static void Marge(int[] arr,int left,int mid,int right,int[] temp)
        {
            int i = left;
            int j = mid + 1;
            int index = 0;

            while (i <= mid && j <= right)
            {
                if (arr[i] < arr[j])
                {
                    temp[index++] = arr[i++];
                }
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
