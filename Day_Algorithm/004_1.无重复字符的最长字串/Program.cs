using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

示例 1:

输入: "abcabcbb"
输出: 3 
解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
示例 2:

输入: "bbbbb"
输出: 1
解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
示例 3:

输入: "pwwkew"
输出: 3
解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
     请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
*/

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "pwwkew";
            Console.WriteLine(GetNoRepString(str));
        }

        static string GetNoRepString(string str)
        {
            int i = 0;
            int j = 0;
            int max = 1;
            int startIndex = 0;

            while (i < str.Length && j <str.Length - 1)
            {
                j++;

                int index = i;
                bool isHave = false;

                while (index < j && j < str.Length)
                {
                    if (str[index++] == str[j])
                    {
                        isHave = true;
                        break;
                    }
                }

                if (!isHave)
                {
                    if ((j - i +1) > max)
                    {
                        max = j - i + 1;
                        startIndex = i;
                    }
                }
                else
                {
                    i = j;
                }
            }
            return str.Substring(startIndex, max);
        }
    }
}
