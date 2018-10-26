using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqStack : ISeqStack
    {
        int[] arr;
        int top;
        int[] min;
        int[] max;

        public SeqStack(int len)
        {
            arr = new int[len];
            min = new int[len];
            max = new int[len];
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
            SetMax(item);
            top++;
        }

        //构造最小元素
        public void SetMin(int item)
        {
            if(top == -1)
            {
                min[top + 1] = item;
            }
            else
            {
                int topNum = min[top];
                if(item < topNum)
                {
                    min[top + 1] = item;
                }
                else
                {
                    min[top + 1] = topNum;
                }
            }
        }

        public void SetMax(int item)
        {
            if(top == -1)
            {
                max[top + 1] = item;
            }
            else
            {
                int topNum = max[top];
                if(item > topNum)
                {
                    max[top + 1] = item;
                }
                else
                {
                    max[top + 1] = topNum;
                }
            }
        }

        public int GetMin()
        {
            return min[top];
        }

        public int GetMax()
        {
            return max[top];
        }
    }
}
