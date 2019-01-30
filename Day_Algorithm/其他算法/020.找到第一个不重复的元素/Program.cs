using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {45, 78, 65, 12, 2, 13, 4, 8, 5, 1, 13, 4};
            Console.WriteLine(FindNoReNum(arr));
        }

        static int FindNoReNum(int[] arr)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!temp.ContainsKey(arr[i]))
                {
                    temp[arr[i]] = 0;
                }

                if (temp[arr[i]] == 0)
                {
                    temp[arr[i]]++;
                }
                else if (temp[arr[i]] == 1)
                    return arr[i];
            }

            return -1;
        }
    }
}
