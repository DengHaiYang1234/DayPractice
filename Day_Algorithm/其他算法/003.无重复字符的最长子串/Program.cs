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
            string s = "pwwkew";
            string str = "";
            int count = LengthOfLongestSubstring(s, out str);
            Console.WriteLine("count:" + count);
            Console.WriteLine("str:" + str);
        }

        static int LengthOfLongestSubstring(string s,out string str)
        {
            Dictionary<int, string> map = new Dictionary<int, string>();
            int maxNum = 0;
            string maxStr = "";
            int count = 0;
            string text = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (text.IndexOf(s[i]) == -1) //未找到相同的字符
                {
                    count++;
                    text += s[i];
                }
                else
                {
                    if (count > maxNum)
                    {
                        maxNum = count;
                        maxStr = text;
                    }
                    count = 1;
                    text = "" + s[i];
                }
            }
            str = maxStr;
            return maxNum;
        }
    }
}
