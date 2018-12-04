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

        public SeqStack() : this(10)
        {
            
        }

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
            int value = arr[top];
            top--;
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
                    min[top + 1] = item;
                else
                    min[top + 1] = topValue;
            }
        }

        public int GetMin()
        {
            return min[top];
        }
    }
}
