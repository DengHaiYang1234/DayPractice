using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
只出现一次的数字
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5,5,1,1,6,7,6,8,8};

            Console.WriteLine(arr[Solution(arr)]);

            Console.WriteLine(NewSolution(arr));
        }

        static int Solution(int[] arr)
        {
            int i = 0;
            int j = i + 1;
            int index = -1;

            while (i < arr.Length)
            {
                if (j >= arr.Length)
                {
                    index = i;
                    break;
                }

                if (arr[i] == arr[j])
                {
                    if (j == i + 1)
                    {
                        i = i + 2;
                    }
                    else
                        i++;

                    j = i + 1;
                }
                else
                {
                    if (j < arr.Length)
                    {
                        j++;
                    }
                }
            }

            if (index == -1)
            {
                Console.WriteLine("未找到");
                return -1;
            }

            return index;
        }


        static int NewSolution(int[] arr)
        {
            int num = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                num = num ^ arr[i];
            }

            return num;
        }
    }
}
