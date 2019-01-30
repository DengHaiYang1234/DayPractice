using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
希尔排序是把记录按下标的一定增量分组，对每组使用直接插入排序算法排序；随着增量逐渐减少，每组包含的关键词越来越多，当增量减至1时，整个文件恰被分成一组，算法便终止。
参考：https://www.cnblogs.com/chengxiao/p/6104371.html
*/
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 2, 7, 9, 8, 3, 6 };
            Sort(arr);
            for(int i = 0; i < arr.Length;i++)
                Console.WriteLine(arr[i]);
        }

        static void Sort(int[] arr)
        {
            for (int gap = arr.Length/2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    int j = i;
                    int temp = arr[j];
                    if (arr[j] < arr[j - gap])
                    {
                        while (j - gap >= 0 && temp < arr[j - gap])
                        {
                            arr[j] = arr[j - gap];
                            j -= gap;
                        }
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
