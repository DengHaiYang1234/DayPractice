using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 洗牌
 * 打乱数组
 * 打乱一个没有重复元素的数组。

示例:

// 以数字集合 1, 2 和 3 初始化数组。
int[] nums = {1,2,3};
Solution solution = new Solution(nums);

// 打乱数组 [1,2,3] 并返回结果。任何 [1,2,3]的排列返回的概率应该相同。
solution.shuffle();

// 重设数组到它的初始状态[1,2,3]。
solution.reset();

// 随机返回数组[1,2,3]打乱后的结果。
solution.shuffle();

*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static Random _random;
        private static int[] _source;

        static void Solution(int[] nums)
        {
            _random = new Random();
            Array.Copy(nums, _source, nums.Length);
        }

        static int[] Reset()
        {
            return _source;
        }

        static  int[] Shuffle()
        {
            int[] shiffled = new int[_source.Length];

            Array.Copy(_source, shiffled, _source.Length);

            for (int i = 0; i < shiffled.Length; i++)
            {
                int randomIndex = _random.Next(_source.Length - i) + i;
                int temp = shiffled[i];
                shiffled[i] = shiffled[randomIndex];
                shiffled[randomIndex] = temp;
            }

            return shiffled;
        }
    }
}
