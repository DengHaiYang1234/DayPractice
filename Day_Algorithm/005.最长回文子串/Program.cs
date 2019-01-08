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
            Console.WriteLine("最长回文：" + LongestPalindrome_manacher("aasaaddddddsssssdddddd"));
        }

        //O（n^3）
        static string LongestPalindrome(string s)
        {
            if (s == "") return "";

            int maxLen = 1;
            int startIndex = 0;
            int len = s.Length;

            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    int leftIndex = i;
                    int rightIndex = j;

                    while (leftIndex < rightIndex && s[leftIndex] == s[rightIndex])
                    {
                        leftIndex++;
                        rightIndex--;
                    }

                    if (leftIndex >= rightIndex && j - i + 1 > maxLen) //取中间
                    {
                        startIndex = i;
                        maxLen = j - i + 1;
                    }
                }
            }

            return s.Substring(startIndex, maxLen);
        }

        //中心扩展法  O（n^2）
        static string LongestPalindrome_1(string s)
        {
            if (s == "") return "";

            int maxLen = 1;
            int startIndex = 0;
            int len = s.Length;

            //找偶数
            for (int i = 0; i < len; i++)
            {
                int leftIndex = i;
                int rightIndex = i + 1;

                while (leftIndex >= 0 && rightIndex < len && s[leftIndex] == s[rightIndex])
                {
                    if (rightIndex - leftIndex + 1 > maxLen)
                    {
                        startIndex = leftIndex;
                        maxLen = rightIndex - leftIndex + 1;
                    }
                    leftIndex--;
                    rightIndex++;
                }
            }

            //找奇数
            for (int i = 0; i < len; i++)
            {
                int leftIndex = i - 1;
                int rightIndex = i + 1;

                while (leftIndex >= 0 && rightIndex < len && s[leftIndex] == s[rightIndex])
                {
                    if (rightIndex - leftIndex + 1 > maxLen)
                    {
                        startIndex = leftIndex;
                        maxLen = rightIndex - leftIndex + 1;
                    }

                    leftIndex--;
                    rightIndex++;
                }
            }

            return s.Substring(startIndex, maxLen);
        }


        //manacher  O（n）
        static string LongestPalindrome_manacher(string s)
        {
            StringBuilder sb = new StringBuilder("^");
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append("#").Append(s[i]);
            }

            sb.Append("#$");

            int c = 0;
            int r = 0;
            int len = sb.Length;
            int centerIndex = 0;
            int maxLen = 0;

            int[] p = new int[len];

            for (int i = 1; i < len - 1; i++)
            {
                int iMirror = 2*c - i;

                p[i] = r > i ? Math.Min(r - i, p[iMirror]) : 0;

                while (i + p[i] < len && i - p[i] > 0 &&  sb[i - 1 - p[i]] == sb[i + 1 + p[i]])
                {
                    p[i]++;
                }

                if (i + p[i] > r)
                {
                    c = i;
                    r = i + p[i];
                }

                if (p[i] > maxLen)
                {
                    maxLen = p[i];
                    centerIndex = i;
                }
            }
            return s.Substring((centerIndex - 1 - maxLen) / 2);
        }





    }
}
