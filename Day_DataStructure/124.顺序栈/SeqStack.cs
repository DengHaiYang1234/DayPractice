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

        public SeqStack() : this(10)
        {
            
        }

        public int Count
        {
            get
            {
                int count = top + 1;
                return count;
            }
        }

        public void Clear() => top = -1;
        
        public int Peek()
        {
            if (top < 0)
            {
                Console.WriteLine("is null");
                return -1;
            }
            return arr[top];
        }

        public int Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("is null");
                return -1;
            }
            int data = arr[top--];
            return data;
        }

        public void Push(int item)
        {
            if (top >= arr.Length)
            {
                Console.WriteLine("is Full");
                return;
            }

            SetMin(item);
            arr[top] = item;
        }

        public void SetMin(int item)
        {
            if (top == -1)
            {
                min[++top] = item;
            }
            else
            {
                int baseValue = min[top];
                if (item > baseValue)
                    min[++top] = baseValue;
                else
                    min[++top] = item;
            }
        }

        public int GetMin()
        {
            if (top < 0)
            {
                Console.WriteLine("is null");
                return -1;
            }
            return min[top];
        }
    }
}
