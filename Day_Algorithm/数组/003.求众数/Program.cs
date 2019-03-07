using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
求众数
给定一个大小为 n 的数组，找到其中的众数。众数是指在数组中出现次数大于 ⌊ n/2 ⌋ 的元素。

你可以假设数组是非空的，并且给定的数组总是存在众数。
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 2, 1, 1, 1, 2,1,1,1,1,2,2};
            Console.WriteLine(Solution(nums));
            Console.WriteLine(Solution_1(nums));
            Console.WriteLine(Solution_2(nums));
            Console.WriteLine(Solution_3(nums));
        }

        static int Solution(int[] nums)
        {
            int baseValue = nums.Length/2;

            Dictionary<int, int> count = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (count.ContainsKey(nums[i]))
                {
                    count[nums[i]]++;

                    if (count[nums[i]] > baseValue)
                    {
                        return nums[i];
                    }
                }
                else
                    count[nums[i]] = 1;
            }

            return -1;
        }

        static int Solution_1(int[] nums)
        {
            int midCount = nums.Length/2;
            int count = 0;
            int j = 0;

            while (j < nums.Length)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[j] == nums[i])
                    {
                        count++;

                        if (count > midCount)
                        {
                            return nums[i];
                        }
                    }
                }

                count = 0;

                j++;
            }

            return -1;
        }

        static int Solution_2(int[] nums)
        {
            int count = 1;
            int maj = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (maj == nums[i])
                    count++;
                else
                {
                    count--;
                    if (count == 0)
                    {
                        maj = nums[i + 1];
                    }
                }
            }
            return maj;
        }

        //正解
        //从第一个数开始count=1，遇到相同的就加1，遇到不同的就减1，减到0就重新换个数开始计数，总能找到最多的那个
        static int Solution_3(int[] nums)
        {
            int count = 1;
            int baseValue = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (baseValue == nums[i])
                {
                    count++;
                }
                else
                {
                    count--;
                    if (count == 0)
                    {
                        baseValue = nums[i + 1]; //重新开始计数
                    }
                }
            }

            return baseValue;
        }
    }
}
