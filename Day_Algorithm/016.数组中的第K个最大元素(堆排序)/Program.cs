using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
堆是具有以下性质的完全二叉树：每个结点的值都大于或等于其左右孩子结点的值，称为大顶堆；或者每个结点的值都小于或等于其左右孩子结点的值，称为小顶堆。
堆排序参考：http://www.cnblogs.com/chengxiao/p/6129630.html


【数组中的第K个最大元素】(找第几个最大元素)

在未排序的数组中找到第 k 个最大的元素。请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。

示例 1:

输入: [3,2,1,5,6,4] 和 k = 2
输出: 5
示例 2:

输入: [3,2,3,1,2,4,5,5,6] 和 k = 4
输出: 4
说明:

你可以假设 k 总是有效的，且 1 ≤ k ≤ 数组的长度。

*/
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 2, 1, 5, 6, 4 };
            Sort(arr);
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
            
            Console.WriteLine("第K个最大元素:" + FindKthLargest(arr,2));
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            return nums[k - 1];
        }

        public static void Sort(int[] arr)
        {
            //构建大顶堆或小顶堆
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                adjustHeap(arr, i, arr.Length);
            }

            for (int i = arr.Length - 1; i > 0; i--)
            {
                Swap(arr, 0, i);//替换最大(最小)元素至末尾
                adjustHeap(arr, 0, i);//在i之内继续找最大（最小）的元素放置首位
            }
        }

        /// <summary>
        /// 选择合适的堆  大顶堆 头元素最大  小顶堆 头元素最小
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="length"></param>
        public static void adjustHeap(int[] arr, int i, int length)
        {
            int temp = arr[i];
            int k = i * 2 + 1;
            while (k < length)
            {
                //若当前节点的右节点满足条件
                if (k + 1 < length && arr[k] > arr[k + 1])// < 大顶堆  > 小顶堆
                {
                    k++;
                }

                if (arr[k] < temp)// > 大顶堆  < 小顶堆
                {
                    arr[i] = arr[k];//i位置设置当前最大（最小）元素
                    i = k;
                }
                else
                    break;

                k = k * 2 + 1;
            }



            //for (int k = i * 2 + 1; k < length; k = k * 2 + 1)
            //{
            //    if (k + 1 < length && arr[k] < arr[k + 1])  // < 大顶堆  > 小顶堆
            //        k++;

            //    if (arr[k] > temp)// > 大顶堆  < 小顶堆
            //    {
            //        arr[i] = arr[k]; //i位置设置当前最大（最小）元素
            //        i = k;
            //    }
            //    else
            //        break;
            //}
            arr[i] = temp;

        }

        public static void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
