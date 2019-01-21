using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 7, 8, 9, 4, 5, 6, 2, 5, 7, 8, 9, 3, 55, 66, 7, 88, 99 };
            Sort(arr);
            for (int i = 0; i < arr.Length - 1; i++)
                Console.WriteLine(arr[i]);
        }

        static void Sort(int[] arr)
        {
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                AdjustHeap(arr, i, arr.Length);
            }

            for (int i = arr.Length - 1; i > 0; i--)
            {
                Swap(arr, 0, i);
                AdjustHeap(arr, 0, i);
            }
        }

        static void AdjustHeap(int[] arr,int index,int length)
        {
            int temp = arr[index];
            int k = index*2 + 1;  //左节点

            while (k < length)
            {
                if (k + 1 < length && arr[k] < arr[k + 1]) //若右节点大于左节点
                    k++;

                if (arr[k] > temp)
                {
                    arr[index] = arr[k];
                    index = k;
                }
                else
                    break;

                k = k*2 + 1;
            }
            arr[index] = temp;
        }

        static void Swap(int[] arr,int a,int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
