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
            int[] arr = new int[] { 5, 4, 5, 6, 8, 6, 4, 4, 5, 1, 34, 67, 8, 4, 4, 4, 3 };

            Sort(arr);

            for(int i = 0;i < arr.Length;i++)
            {
                Console.WriteLine(arr[i]);
            }
        }


        static void Sort(int[] arr)
        {
            for(int i = 0;i < arr.Length;i++)
            {
                for(int j = arr.Length - 1;j > i;j--)
                {
                    if(arr[i] > arr[j])
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
