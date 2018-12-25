using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("最长回文：" + LongestPalindrome_1("sdsdsdsdsdsdsd"));
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

    }
}
