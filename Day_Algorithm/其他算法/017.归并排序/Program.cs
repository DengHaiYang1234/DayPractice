using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
归并排序（MERGE-SORT）是利用归并的思想实现的排序方法，该算法采用经典的分治（divide-and-conquer）策略（分治法将问题分(divide)成一些小的问题然后递归求解，而治(conquer)的阶段则将分的阶段得到的各答案"修补"在一起，即分而治之)。
参考：https://www.cnblogs.com/chengxiao/p/6194356.html

*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4,5,6,8,9,1,2,32,3,44,2,3,4,4};
            Sort(arr);
            for(int i = 0; i < arr.Length;i++)
                Console.WriteLine(arr[i]);
        }

        public static void Sort(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Sort(arr, 0, arr.Length - 1, temp);
        }

        private static void Sort(int[] arr,int left,int right,int[] temp)
        {
            if (left < right)
            {
                int mid = (left + right)/2;
                Sort(arr, left, mid, temp);
                Sort(arr, mid + 1, right, temp);
                Merge(arr, left, mid, right, temp);
            }
        }

        private static void Merge(int[] arr,int left,int mid,int right,int[] temp)
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
