using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SeqStack : ISeqStack
    {
        private int[] arr;
        private int[] minArr;
        private int top;

        public int Count
        {
            get
            {
                int _count = top;
                return ++_count;
            }
        }

        public SeqStack(int len)
        {
            arr = new int[len];
            minArr = new int[len];
            top = -1;
        }

        public int Peek()
        {
            if (top < 0)
            {
                Console.WriteLine("越界");
                return -1;
            }
            return arr[top];
        }

        public int Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("越界");
                return -1;
            }

            int value = arr[top];
            GetMin();
            top--;
            return value;
        }

        public void Push(int item)
        {
            arr[top + 1] = item;
            SetMin(item);
            top++;
        }

        public void Clear() => top = -1;

        public void SetMin(int item)
        {
            if (top == -1)
                minArr[top + 1] = item;
            else
            {
                int topItem = minArr[top];

                if (item > topItem)
                {
                    minArr[top + 1] = topItem;
                }
                else
                {
                    minArr[top + 1] = item;
                }
            }
        }

        public int GetMin()
        {
            return minArr[top];
        }
    }
}
