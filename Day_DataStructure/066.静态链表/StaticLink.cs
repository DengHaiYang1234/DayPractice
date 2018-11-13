using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Link
    {
        public string data;
        public int cur;  //游标
    }

    public class StaticLink
    {
        private int length = 0;

        static readonly int MAXSIZE = 10;
        public static Link[] arr;

        public StaticLink()
        {
            arr = new Link[MAXSIZE];
            Init();
        }

        void Init()
        {
            for (int i = 0; i < MAXSIZE; i++)
            {
                arr[i] = new Link();
                arr[i].cur = i + 1;
            }
            //数组最后一个元素的cur用来存放第一个插入元素的下标，相当于头结点(第一个有数值的元素下标)
            arr[MAXSIZE - 1].cur = 1;
        }

        //返回第一个可用位置
        int Malloc()
        {
            int i = arr[0].cur; //当前数组第一个元素的cur存的值  就是要返回的第一个备用空闲的下标
            if (arr[0].cur > 0)
            {
                //下一空闲的游标分量
                arr[0].cur = arr[i].cur; //由于要拿出一个分量来使用了，所以我们就得把它的下一个分量来做备用//
            }
            return i;
        }

        public void Add(Link link)
        {
            int temp = Malloc();
            arr[temp].data = link.data;
            arr[temp].cur = arr[0].cur;
            length++;
        }

        public void Insert(int size,Link link)
        {
            if (size > arr[0].cur)
                return;

            //空闲分量游标
            int free_Length = Malloc();
            //首先是最后一个元素的下标
            int temp = MAXSIZE - 1;
            for (int i = 1; i < size - 1; i++) //找到第size个元素之前的位置
                temp = arr[temp].cur; //最后一个小标位置的cur指向的有值的头结点

            link.cur = arr[temp].cur; //把第size个元素之前的cur赋值给新元素的cur
            arr[temp].cur = free_Length; //把新元素的下标赋值给第size个元素之前元素的cur
            arr[free_Length] = link;
            length++;
        }

        public void Delete(int size)
        {
            if (size >= arr[0].cur)
                return;
            int k = arr[MAXSIZE - 1].cur;
            for (int i = 1; i < size - 1; i++)
                k = arr[k].cur;

            int temp = arr[k].cur;
            arr[k].cur = arr[temp].cur;
            Free(temp);
            length--;
        }

        void Free(int i )
        {
            arr[i].cur = arr[0].cur;
            arr[i].data = null;
            arr[0].cur = i;
        }
    }
}
