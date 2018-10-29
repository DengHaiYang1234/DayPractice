using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class SeqQueue : ISeqQueue
    {
        private int[] arr;
        private int count;
        private int pre;
        private int end;

        private Stack<int> stack_1 = new Stack<int>();
        //private Stack<int> stack_2 = new Stack<int>();
        private Stack<int> minStack = new Stack<int>();

        public SeqQueue(int len)
        {
            arr = new int[len];
            count = 0;
            pre = 0;
            end = 0;
        }

        public SeqQueue() : this(15)
        {
            
        }

        public void Clear()
        {
            count = 0;
            pre = end = 0;
        }

        public int Count {
            get { return count; }
        }


        public void Enqueue(int item)
        {
            if (end >= arr.Length)
            {
                end = 0;
                count = arr.Length;
            }

            arr[end] = item;
            end++;
            Push(stack_1, pre, end);
            if (count != arr.Length)
            {
                count++;
            }
        }

        public int Dequeue()
        {
            if (pre >= arr.Length)
            {
                pre = 0;
            }

            int value = arr[pre];
            pre++;



            Push(stack_1, pre, end);
            count--;
            return value;
        }

        public int Peek()
        {
            return arr[pre + 1];
        }

        public bool IsEmpty() => count == 1;


        #region  找最小值

        //先入栈
        void Push(Stack<int> stack,int forntIndex,int endIndex)
        {
            for (int i = forntIndex; i < endIndex; i++)
            {
                stack.Push(arr[i]);
            }

            SetMin(stack);
        }

        //出栈时找出最小值
        void SetMin(Stack<int> stack)
        {
            minStack.Clear();
            while (stack.Count > 0)
            {
                int valueNum = stack.Peek();
                if (minStack.Count == 0)
                {
                    minStack.Push(valueNum);
                }
                else
                {
                    int minNum = minStack.Peek();
                    if (valueNum < minNum)
                        minStack.Push(valueNum);
                    else
                        minStack.Push(minNum);
                }
                stack.Pop();
            }
        }
        
        public int GetMin()
        {
            Console.WriteLine("最小值为：" + minStack.Peek());
            return minStack.Peek();
        }

        #endregion

    }
}
