using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
数据流的中位数
中位数是有序列表中间的数。如果列表长度是偶数，中位数则是中间两个数的平均值。

例如，

[2,3,4] 的中位数是 3

[2,3] 的中位数是 (2 + 3) / 2 = 2.5

设计一个支持以下两种操作的数据结构：

void addNum(int num) - 从数据流中添加一个整数到数据结构中。
double findMedian() - 返回目前所有元素的中位数。
示例：

addNum(1)
addNum(2)
findMedian() -> 1.5
addNum(3) 
findMedian() -> 2
进阶:

如果数据流中所有整数都在 0 到 100 范围内，你将如何优化你的算法？
如果数据流中 99% 的整数都在 0 到 100 范围内，你将如何优化你的算法？

参考：https://blog.csdn.net/qq_33575542/article/details/80881015
*/
namespace Project
{
    class Program
    {
        private static List<int> _max = new List<int>();//容器右边较大数所存储的堆

        private static List<int> _min = new List<int>();//容器左边较小数所存储的堆

        static void Main(string[] args)
        {
            int[] num = { 2, 3 };

            for (int i = 0; i < num.Length; i++)
            {
                Insert(num[i]);
            }

            Console.WriteLine(GetMidNum());
        }

        /// <summary>
        /// 首先需要保证最大堆和最小堆能够平均分配数据，因此两个堆的数目差不能超过1.为了实现平均分配，可以在数据的总数目是偶数时把新数据插入最小堆，否则插入最大堆。
        /// </summary>
        /// <param name="num"></param>
        static void Insert(int num)
        {
            //如果两个容器数量不平衡，则让其保持平衡，把新数据添加到max中
            if (((_max.Count + _min.Count) & 1) == 0)
            {
                //新插入的数据大于最小堆的最大值，那么先把这个数据添加进最大堆，然后取出最大堆的最小值，把最小值插入最小堆min中
                if (_min.Count > 0 && num > _min[0])
                {
                    _min.Add(num);
                    num = _min[0];
                    _min.Remove(num);
                }
                _max.Add(num);
            }
            else
            {
                //如果要把新数据插入最大堆max，先判断新数据是否小于最小堆的最大值，如果是，那么先把新数据插入最小堆，取出最小堆的最大值，
                //把得到的最大值插入最大堆max中
                if (_max.Count > 0 && num < _max[_max.Count - 1])
                {
                    _max.Add(num);
                    num = _max[_max.Count - 1];
                    _max.Remove(num);
                }
                _min.Add(num);
            }
        }

        static double GetMidNum()
        {
            int size = _max.Count + _min.Count;
            if (size == 0)
                return 0.0;

            if ((size & 1) == 0)
                return (_max[_max.Count - 1] + _min[0])/2.0;
            else
                return (double) _max[_max.Count - 1];

        }
    }

    
}
