using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。

示例 1:

输入: 123
输出: 321
 示例 2:

输入: -123
输出: -321
示例 3:

输入: 120
输出: 21
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reverse(-123));
        }

        static int Reverse(int data)
        {
            Stack<char> stack = new Stack<char>();

            string str = data.ToString();
            char symbol = str[0];
            int index = 0;

            if (symbol == '-')
            {
                index = 1;
            }
            
            while (index < str.Length)
            {
                stack.Push(str[index]);
                index++;
            }

            string s = "";

            if (symbol == '-')
            {
                s += symbol;
            }

            while (stack.Count > 0)
            {
                char value = stack.Pop();
                if (value != '0')
                {
                    s += value;
                }
            }

            if (s == "")
            {
                Console.WriteLine("空字符串!");
                return -1;
            }

            return int.Parse(s);

        }
    }
}
