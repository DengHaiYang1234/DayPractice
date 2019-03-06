using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
反转字符串
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] str = { 'H', 'a', 'n', 'n', 'a' ,'h'};
            char[] arr = Solution(str);
            char[] arr1 = NewSolution(str);

            Console.WriteLine(new string(arr));
            Console.WriteLine(new string(arr1));
            
            
        }

        static char[] Solution(char[] arr)
        {
            char[] newChar = new char[arr.Length];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                newChar[arr.Length - 1 - i] = arr[i];
            }


            return newChar;


        }

        static char[] NewSolution(char[] arr)
        {
            char[] newChar = new char[arr.Length];

            int i = 0;
            int j = arr.Length - 1;

            while (i < arr.Length || j >= 0)
            {
                newChar[i++] = arr[j--];
            }

            return newChar;
        }


        
    }
}
