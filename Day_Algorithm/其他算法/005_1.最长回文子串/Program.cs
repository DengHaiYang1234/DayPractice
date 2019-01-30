using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。
示例 1：
输入: "babad"
输出: "bab"
注意: "aba" 也是一个有效答案。
示例 2：
输入: "cbbd"
输出: "bb"
*/


namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "cbbd";
            Console.WriteLine(CenterExtension_1(s));
        }

        static string LongestPalindrome(string s)
        {
            if (s == "") return "";

            int max = 1;
            int startIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    int leftIndex = i;
                    int rightIndex = j;

                    while (leftIndex < rightIndex && s[leftIndex] == s[rightIndex])
                    {
                        leftIndex++;
                        rightIndex--;
                    }


                    if (leftIndex >= rightIndex && j - i + 1 > max)
                    {
                        max = j - i + 1;
                        startIndex = i;
                    }
                }
            }

            return s.Substring(startIndex, max);
        }

        static string LongestPalindrome_1(string s)
        {
            if (s == "") return "";

            int max = 1;
            int startIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j < s.Length; j++)
                {
                    int leftIndex = i;
                    int rightIndex = j;

                    while (leftIndex < rightIndex && s[leftIndex] == s[rightIndex])
                    {
                        leftIndex++;
                        rightIndex--;
                    }

                    if (leftIndex >= rightIndex && j - i + 1 > max)
                    {
                        max = j - i + 1;
                        startIndex = i;
                    }
                }
            }

            return s.Substring(startIndex, max);
        }

        static string CenterExtension(string s)
        {
            int max = 1;
            int startIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int leftIndex = i;
                int rightIndex = i + 1;

                while (leftIndex >= 0 && rightIndex < s.Length && s[leftIndex] == s[rightIndex])
                {
                    if (rightIndex - leftIndex + 1 > max)
                    {
                        startIndex = leftIndex;
                        max = rightIndex - leftIndex;
                    }

                    leftIndex--;
                    rightIndex++;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                int leftIndex = i;
                int rightIndex = i + 2;

                while (leftIndex >= 0 && rightIndex < s.Length && s[leftIndex] == s[rightIndex])
                {
                    if (rightIndex - leftIndex + 1 > max)
                    {
                        startIndex = leftIndex;
                        max = rightIndex - leftIndex + 1;
                    }

                    leftIndex--;
                    rightIndex++;
                }
            }

            return s.Substring(startIndex, max);
        }

        static string CenterExtension_1(string s)
        {
            if (s == "") return "";

            int max = 1;
            int startIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int leftIndex = i;
                int rightIndex = i + 1;

                while (leftIndex >= 0 && rightIndex < s.Length && s[leftIndex] == s[rightIndex])
                {
                    if (rightIndex - leftIndex + 1 > max)
                    {
                        startIndex = leftIndex;
                        max = rightIndex - leftIndex + 1;
                    }

                    leftIndex--;
                    rightIndex++;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                int leftIndex = i;
                int rightIndex = i + 2;

                while (leftIndex >= 0 && rightIndex < s.Length && s[leftIndex] == s[rightIndex])
                {

                    if (rightIndex - leftIndex + 1 > max)
                    {
                        startIndex = leftIndex;
                        max = rightIndex - leftIndex + 1;
                    }

                    leftIndex--;
                    rightIndex++;
                }
            }

            return s.Substring(startIndex, max);
        }
    }
}
