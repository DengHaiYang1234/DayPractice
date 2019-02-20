using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqStack : ISeqStack
    {
        private int[] arr;
        private int[] min;
        private int top;

        public SeqStack(int len)
        {
            arr = new int[len];
            min = new int[len];
            top = -1;
        }

        public int Count
        {
            get
            {
                int count = top;
                return ++count;
            }
        }

        public void Clear() => top = -1;
       

        public int Peek()
        {
            return arr[top];
        }

        public int Pop()
        {
            if (top <= -1)
            {
                Console.WriteLine("已空");
                return -1;
            }

            return arr[top--];
        }

        public void Push(int item)
        {
            if (top >= arr.Length - 1)
            {
                Console.WriteLine("已满");
                return;
            }

            arr[++top] = item;
            PushMin(item);
        }

        public void PushMin(int item)
        {
            if (top == 0)
            {
                min[top] = item;
            }
            else
            {
                int baseValue = min[top - 1];
                if (baseValue > item)
                {
                    min[top] = item;
                }
                else
                    min[top] = baseValue;
            }
        }

        public int GetMin()
        {
            return min[top];
        }
    }
}
