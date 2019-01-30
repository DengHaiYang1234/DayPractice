using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
给定一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？找出所有满足条件且不重复的三元组。
注意：答案中不可以包含重复的三元组。
例如, 给定数组 nums = [-1, 0, 1, 2, -1, -4]，
满足要求的三元组集合为：
[
  [-1, 0, 1],
  [-1, -1, 2]
]
*/


namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {-1, 0, 1, 2, -1, -4};
            Sort(nums); //堆排序

            Console.WriteLine(nums);
            List<int[]> arr = ThreeNumsAdd(nums);
            Console.WriteLine(arr);
        }

        static List<int[]> ThreeNumsAdd(int[] nums)
        {
            List<int[]> list = new List<int[]>();

            int i = 0;
            int j = i + 1;
            int k = j + 1;

            while (i < nums.Length - 2)
            {
                if (nums[i] + nums[j] + nums[k] == 0)
                {
                    list.Add(new int[] { nums[i], nums[j], nums[k] });
                }

                if (++k >= nums.Length)
                {
                    j++;
                    k = j + 1;
                    if (j >= nums.Length - 1)
                    {
                        if (nums[i] == nums[++i]) //去重复
                        {
                            ++i;
                        }
                        j = i + 1;
                        k = j + 1;
                    }
                }
            }

            return list;
        }


        static void Sort(int[] arr)
        {
            for (int i = arr.Length /2 -1; i >= 0; i --)
            {
                AdjustHeap(arr, i, arr.Length);
            }

            for (int i = arr.Length - 1; i>=0; i--)
            {
                Switch(arr, 0, i);
                AdjustHeap(arr, 0, i);
            }
        }

        static void AdjustHeap(int[] arr,int i ,int length)
        {
            int temp = arr[i];
            int k = i*2+1;

            while (k < length)
            {
                if (k + 1 < length && arr[k] < arr[k + 1])
                {
                    k++;
                }

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

        static void Switch(int[] arr,int a,int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
