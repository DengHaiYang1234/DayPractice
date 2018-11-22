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
        private int top;

        private int[] arrMin;

        public SeqStack(int len)
        {
            arr = new int[len];
            arrMin = new int[len];
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
            if (top >= arr.Length - 1)
            {
                Console.WriteLine(" 栈已满");
                return;
            }

            arr[top + 1] = item;
            SetMin(item);
            top++;
        }

        public void SetMin(int item)
        {
            if (top == -1)
            {
                arrMin[top + 1] = item;
            }
            else
            {
                int value = arrMin[top]; //获取栈顶的值
                if (item < value)
                {
                    arrMin[top + 1] = item;
                }
                else
                {
                    arrMin[top + 1] = value;
                }
            }
        }

        public int GetMin()
        {
            return arrMin[top];
        }
    }
}
