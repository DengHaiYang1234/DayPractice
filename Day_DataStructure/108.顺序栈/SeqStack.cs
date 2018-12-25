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
        private int[] min;
        private int top;

        public SeqStack(int len)
        {
            arr = new int[len];
            min = new int[len];
            top = -1;
        }

        public SeqStack() : this(10)
        {
            
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
            if (top >= 0)
            {
                return arr[top];
            }
            return -1;
        }

        public int Pop()
        {
            int value = -1;
            if (top >= 0)
            {
                value = arr[top];
                top--;
            }

            return value;
        }

        public void Push(int item)
        {
            arr[top + 1] = item;
            SetMin(item);
            top++;
        }

        public void SetMin(int item)
        {
            if (top == -1)
            {
                min[top + 1] = item;
            }
            else
            {
                int topValue = min[top];
                if (item < topValue)
                {
                    min[top + 1] = item;
                }
                else
                {
                    min[top + 1] = topValue;
                }
            }
        }

        public int GetMin()
        {
            if (top > -1)
            {
                return min[top];
            }
            return -1;
        }
    }
}
