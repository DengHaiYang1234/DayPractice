using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//堆排序  构建大顶堆
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr =
            {
                5,8,9,7,4,1,3,
                3,5,7,5
            };

            Sort(arr);

            foreach (var a in arr)
                Console.WriteLine(a);
        }

        static void Sort(int[] arr)
        {
            for (int i = (arr.Length - 1) / 2; i >= 0; i--)
            {
                AdjustHeap(arr, i, arr.Length - 1);
                
            }

            for (int i = arr.Length - 1; i >= 0; i --)
            {
                SwapData(arr, 0, i);
                AdjustHeap(arr, 0, i);
            }
        }

        static void AdjustHeap(int[] arr, int index, int length)
        {
            int temp = arr[index];

            int k = index * 2 + 1;

            while (k < length)
            {
                if (k + 1 < length && arr[k] < arr[k + 1])
                    k++;

                if (arr[k] > temp)
                {
                    arr[index] = arr[k];
                    index = k;
                }
                else
                    break;
                k = k * 2 + 1;
            }
            arr[index] = temp;
        }

        static void SwapData(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
