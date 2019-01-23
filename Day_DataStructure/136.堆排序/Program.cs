using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    /// <summary>
    /// 堆排序
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {4, 7, 8, 9, 5, 32, 3};
            Sort(arr);
            for(int i = 0; i < arr.Length;i++)
                Console.WriteLine(arr[i]);
        }

        static void Sort(int[] arr)
        {
            for (int i = (arr.Length /2)-1; i >= 0; i--)
            {
                AdjustHeap(arr, i, arr.Length);
            }

            for (int i = arr.Length - 1; i >= 0; i --)
            {
                Swap(arr, 0, i);
                AdjustHeap(arr, 0, i);
            }
        }

        static void AdjustHeap(int[] arr,int i,int length)
        {
            int temp = arr[i];
            int k = i*2 + 1;

            while (k < length)
            {
                if (k + 1 < length && arr[k] < arr[k + 1])
                    k++;

                if (arr[k] > temp)
                {
                    arr[i] = arr[k];
                    i = k;
                }
                else
                    break;

                k = k*2 + 1;
            }

            arr[i] = temp;
        }

        static void Swap(int[] arr,int a,int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
