using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 88, 99, 6, 5, 4, 8, 1, 33, 4, 78, 56 };
            Console.WriteLine(FindMax(arr));
        }

        static int FindMax(int[] arr)
        {
            int max = arr[0];
            int secondMax = arr[1];

            if (max < secondMax)
            {
                max = arr[1];
                secondMax = arr[0];
            }

            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    secondMax = max;
                    max = arr[i];
                }
                else if (arr[i] > secondMax)
                {
                    secondMax = arr[i];
                }
            }

            return secondMax;
        }
    }
}
