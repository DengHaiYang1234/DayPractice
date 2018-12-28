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
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ls = ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });

            for (int i = 0; i < ls.Count; i++)
            {
                foreach (var item in ls[i])
                {
                    Console.WriteLine("item:" + item);
                }

                Console.WriteLine("=====================================");
            }
        }

        //O(n^3)
        static List<int[]> ThreeSum(int[] nums)
        {
            int index = 0;

            int len = nums.Length;

            List<int[]> ls = new List<int[]>();

            List<string> str = new List<string>();

            while (index < len)
            {
                int inverseValue = -(nums[index]); //取反
                for (int i = index + 1; i < len; i++)
                {
                    for (int j = i + 1; j < len; j++)
                    {
                        if (nums[i] + nums[j] == inverseValue)
                        {
                            ls.Add(new int[] { nums[index], nums[i], nums[j] });
                            index++;
                            continue;
                        }
                    }
                }
                index++;
            }

            return ls;
        }
    }
}
