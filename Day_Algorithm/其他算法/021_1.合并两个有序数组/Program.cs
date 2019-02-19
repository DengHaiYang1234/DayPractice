using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * 合并两个有序数列
 */
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1};
            int[] b = { 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach(var i in Merge(a,b))
                Console.WriteLine(i);
        }

        static int[] Merge(int[] a,int[] b)
        {
            int[] temp = new int[a.Length + b.Length];
            int index = 0;
            int i = 0;
            int j = 0;

            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])
                {
                    temp[index++] = a[i++];
                }
                else
                    temp[index++] = b[j++];
            }

            while (i < a.Length)
                temp[index++] = a[i++];

            while (j < b.Length)
                temp[index++] = b[j++];

            return temp;
        }

    }
}
