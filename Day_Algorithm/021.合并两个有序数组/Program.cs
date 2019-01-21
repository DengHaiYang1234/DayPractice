using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = {1, 2, 3, 4, 5, 6};
            int[] b = {2, 3, 4, 5, 6, 7, 8, 9};

            int[] c = Marge(a, b);

            for (int i = 0; i < c.Length; i++)
            {
                Console.WriteLine(c[i]);
            }
        }

        static int[] Marge(int[] a,int[] b)
        {
            int len = a.Length + b.Length;
            int[] temp = new int[len];

            int i = 0;
            int j = 0;
            int k = 0;

            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])
                {
                    temp[k++] = a[i++];
                }
                else
                {
                    temp[k++] = b[j++];
                }
            }

            while (i < a.Length)
                temp[k++] = a[i++];

            while (j < b.Length)
                temp[k++] = b[j++];

            return temp;
        }
    }
}
